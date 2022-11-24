using Core.Entities;

namespace Core.Specifications.ProductBrands
{
    public class ProductBrandsSpecification : BaseSpecification<ProductBrand>
    {
        public ProductBrandsSpecification(int id) : base(x => x.Id == id)
        {
        }

        public ProductBrandsSpecification(ProductBrandsParam productBrandsParam)
        {
            ApplyPaging(productBrandsParam.PageSize * (productBrandsParam.PageIndex - 1), productBrandsParam.PageSize);
            AddOrderBy(n => n.Name.ToLower());
            if (!string.IsNullOrEmpty(productBrandsParam.Sort))
            {
                switch (productBrandsParam.Sort)
                {
                    case "idAsc":
                        AddOrderBy(p => p.Id);
                        break;
                    case "idDesc":
                        AddOrderByDescending(m => m.Id);
                        break;
                    default:
                        AddOrderBy(n => n.Name.ToLower());
                        break;
                }
            }
        }

    }

}