using Core.Domain.Entities;

namespace Core.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int? idProduct);
    // Task<Product> GetProductByCategoryAsync(int? idProduct);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> DeleteAsync(Product product);
}
