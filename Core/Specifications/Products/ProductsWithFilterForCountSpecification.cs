using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Products
{
    public class ProductsWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFilterForCountSpecification(ProductSpecParams productSpecParams) : base(x =>
        (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
        (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
        (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))

        {

        }

    }
}
