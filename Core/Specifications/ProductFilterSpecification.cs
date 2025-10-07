using Core.Entities;

namespace Core.Specifications;

public class ProductFilterSpecification : BaseSpecification<Product>
{
    public ProductFilterSpecification(ProductSpecParams productSpecParams) : base(x =>
        (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
        (!productSpecParams.Brands.Any() || productSpecParams.Brands.Contains(x.Brand)) &&
        (!productSpecParams.Types.Any() || productSpecParams.Types.Contains(x.Type)))
    {

        ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

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