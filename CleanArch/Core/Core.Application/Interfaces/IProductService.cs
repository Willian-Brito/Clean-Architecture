using Core.Application.DTOs.Products;

namespace Core.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    // Task<ProductDTO> GetProductCategory(int idProduct);
    Task<ProductDTO> GetById(int? idProduct);
    Task Add(ProductDTO productDTO);
    Task Update(ProductDTO productDTO);
    Task Remove(int? idProduct);
}
