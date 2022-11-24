using Core.Entities;

namespace Core.Specifications.ProductTypes
{
    public class ProductTypesSpecification : BaseSpecification<ProductType>
    {
        public ProductTypesSpecification(int id) : base(x => x.Id == id)
        {
        }

        public ProductTypesSpecification(ProductTypesParams productTypesParams)
        {
            ApplyPaging(productTypesParams.PageSize * (productTypesParams.PageIndex - 1), productTypesParams.PageSize);
            AddOrderBy(n => n.Name.ToLower());
            if (!string.IsNullOrEmpty(productTypesParams.Sort))
            {
                switch (productTypesParams.Sort)
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
