using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _productContext;

    #region Construtor
    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;
    }
    #endregion

    #region Metodos

    #region CreateAsync
    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();

        return product;
    }
    #endregion

    #region DeleteAsync
    public async Task<Product> DeleteAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();

        return product;
    }
    #endregion

    #region GetByIdAsync
    public async Task<Product> GetByIdAsync(int? idProduct)
    {
        return await _productContext.Products.FindAsync(idProduct);
    }
    #endregion

    #region GetProductByCategoryAsync
    public async Task<Product> GetProductByCategoryAsync(int? idProduct)
    {
        return await _productContext.Products.Include(item => item.Category)
                                             .SingleOrDefaultAsync(item => item.IdProduct == idProduct);
    }
    #endregion

    #region GetProductsAsync
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();
    }
    #endregion

    #region UpdateAsync
    public async Task<Product> UpdateAsync(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();

        return product;
    }
    #endregion
    
    #endregion
}
