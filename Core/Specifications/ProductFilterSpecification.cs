using Core.Entities;

namespace Core.Specifications;

public class ProductFilterSpecification : BaseSpecification<Product>
{
    public ProductFilterSpecification(string? brand, string? type) : base(x =>
        (string.IsNullOrEmpty(brand) || x.Brand == brand) &&
        (string.IsNullOrEmpty(type) || x.Type == type))
    {
        
    }
}