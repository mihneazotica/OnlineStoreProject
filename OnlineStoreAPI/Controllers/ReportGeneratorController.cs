using AutoMapper;
using BoldReports.Writer;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Products;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Dtos;

namespace OnlineStoreAPI.Controllers
{
    // for POC
    public class ReportGeneratorController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IGenericRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ReportGeneratorController(IWebHostEnvironment hostingEnvironment,IGenericRepository<Product> productRepo,IMapper mapper)
        {
            _hostingEnvironment = hostingEnvironment;
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        [HttpPost("exportReport")]
        public async Task<IActionResult> Export(string extension)
        {
            var format = extension switch
            {
                "pdf" => WriterFormat.PDF,
                "docx" => WriterFormat.Word,
                "xlsx" => WriterFormat.Excel,
                "csv" => WriterFormat.CSV,
                "html" => WriterFormat.HTML,
                _ => WriterFormat.PDF,
            };
            
            FileStream inputStream = new(_hostingEnvironment.WebRootPath + @"\Resources\ppp.rdlc", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();

            ReportWriter writer = new();
            string fileName = "product-report." + format.ToString().ToLower();

            writer.LoadReport(reportStream);
            writer.ReportProcessingMode = ProcessingMode.Local;
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await productRepo.ListAsync(spec);

            IReadOnlyList<ProductToReturnDtos> mappedProducts = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDtos>>(products);
            writer.DataSources.Add( new BoldReports.Web.ReportDataSource { Name= "list", Value= mappedProducts });
            writer.Save(reportStream, format);
            
            reportStream.Position = 0;

            FileStreamResult fileStreamResult = new(reportStream, "application/" + format)
            {
                FileDownloadName = fileName
            };

            return fileStreamResult;
        }
    }
   
 
}
