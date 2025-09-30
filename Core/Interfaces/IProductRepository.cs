using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<string>> GetAllProductBrandsAsync();
    Task<IReadOnlyList<string>> GetAllProductTypesAsync();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();
}