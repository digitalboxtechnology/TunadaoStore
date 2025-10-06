using Core.Entities;

namespace Core.Specifications;

public class ProductFilterSpecification : BaseSpecification<Product>
{
    public ProductFilterSpecification(ProductSpecParams productSpecParams) : base(x =>
        (!productSpecParams.Brands.Any() || productSpecParams.Brands.Contains(x.Brand)) &&
        (!productSpecParams.Types.Any() || productSpecParams.Types.Contains(x.Type)))
    {
        switch (productSpecParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(p => p.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(p => p.Price);
                break;
            default:
                AddOrderBy(p => p.Name);
                break;
        }
    }
}