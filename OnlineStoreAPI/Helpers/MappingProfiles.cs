using AutoMapper;
using Core.Entities;
using OnlineStoreAPI.Dtos;

namespace OnlineStoreAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDtos>()
                 .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                 .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                 .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            

            CreateMap<ProductToPostDtos, Product>()
                .ForMember(d => d.ProductBrand, o => o.Ignore())
                .ForMember(d => d.ProductType, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<ProductBrandToPostDto,ProductBrand>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<ProductTypeToPostDto, ProductType>()
                .ForMember(d => d.Id, o => o.Ignore());


        }
    }
}

