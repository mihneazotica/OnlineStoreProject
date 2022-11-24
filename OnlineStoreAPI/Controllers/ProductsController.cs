using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.ProductBrands;
using Core.Specifications.Products;
using Core.Specifications.ProductTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OnlineStoreAPI.Dtos;
using OnlineStoreAPI.Errors;
using OnlineStoreAPI.Helpers;

namespace OnlineStoreAPI.Controllers
{
    public class ProductsController : BaseController
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepo = productRepository;
            _productBrandRepo = productBrandRepository;
            _productTypeRepo = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDtos>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFilterForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDtos>>(products);
            return Ok(new Pagination<ProductToReturnDtos>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDtos>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product, ProductToReturnDtos>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<Pagination<ProductBrand>>> GetProductBrands([FromQuery] ProductBrandsParam productBrandsParam)
        {
            var spec = new ProductBrandsSpecification(productBrandsParam);
            var totalItems = await _productBrandRepo.CountAsync(spec);
            var productBrands = await _productBrandRepo.ListAsync(spec);
            return Ok(new Pagination<ProductBrand>(productBrandsParam.PageIndex, productBrandsParam.PageSize, totalItems, productBrands));
        }

        [HttpGet("types")]
        public async Task<ActionResult<Pagination<ProductType>>> GetProductTypes([FromQuery] ProductTypesParams productTypesParams)
        {
            var spec = new ProductTypesSpecification(productTypesParams);
            var totalItems = await _productTypeRepo.CountAsync(spec);
            var productTypes = await _productTypeRepo.ListAsync(spec);
            return Ok(new Pagination<ProductType>(productTypesParams.PageIndex, productTypesParams.PageSize, totalItems, productTypes));
        }

        [HttpPost]
        public async Task<ActionResult<ProductToPostDtos>> AddProduct(ProductToPostDtos product)
        {
            var newProduct = _mapper.Map<ProductToPostDtos, Product>(product);

            if (string.IsNullOrEmpty(newProduct.Name))
            {
                return BadRequest(new ApiResponse(400));
            }

            await _productRepo.AddAsync(newProduct);
            return Ok(product);
        }

        [HttpPost("types")]
        public async Task<ActionResult<ProductTypeToPostDto>> AddProductType([FromQuery] ProductTypeToPostDto productType)
        {
            var newProductType = _mapper.Map<ProductTypeToPostDto, ProductType>(productType);

            if (string.IsNullOrEmpty(productType.Name))
            {
                return BadRequest(new ApiResponse(400));
            }
            await _productTypeRepo.AddAsync(newProductType);

            return Ok(productType);
        }

        [HttpPost("brands")]
        public async Task<ActionResult<ProductBrandToPostDto>> AddProductBrand(ProductBrandToPostDto productBrand)
        {
            var newProductBrand = _mapper.Map<ProductBrandToPostDto, ProductBrand>(productBrand);

            if (string.IsNullOrEmpty(productBrand.Name))
            {
                return BadRequest(new ApiResponse(400));
            }
            await _productBrandRepo.AddAsync(newProductBrand);
            return Ok(productBrand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            await _productRepo.DeleteAsync(spec);
            return Ok();
        }

        [HttpDelete("brands/{id}")]
        public async Task<ActionResult> DeleteProductBrand(int id)
        {
            var spec = new ProductBrandsSpecification(id);
            var productBrand = await _productBrandRepo.GetEntityWithSpec(spec);
            if (productBrand == null)
            {
                return NotFound(new ApiResponse(404));
            }
            await _productBrandRepo.DeleteAsync(spec);
            return Ok();
        }

        [HttpDelete("types/{id}")]
        public async Task<ActionResult> DeleteProductType(int id)
        {
            var spec = new ProductTypesSpecification(id);
            var productType = await _productTypeRepo.GetEntityWithSpec(spec);
            if (productType == null)
            {
                return NotFound(new ApiResponse(404));
            }
            await _productTypeRepo.DeleteAsync(spec);
            return Ok();
        }

    }
}


