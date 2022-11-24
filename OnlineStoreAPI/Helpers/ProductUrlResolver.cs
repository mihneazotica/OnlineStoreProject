﻿using AutoMapper;
using Core.Entities;
using OnlineStoreAPI.Dtos;

namespace OnlineStoreAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDtos, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDtos destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
