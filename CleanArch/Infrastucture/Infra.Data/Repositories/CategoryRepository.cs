using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDbContext _categoryContext;

    #region Construtor
    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }
    #endregion

    #region Metodos

    #region CreateAsync
    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();

        return category;
    }
    #endregion

    #region DeleteAsync
    public async Task<Category> DeleteAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();

        return category;
    }
    #endregion

    #region GetByIdAsync
    public async Task<Category> GetByIdAsync(int? idCategory)
    {
        return await _categoryContext.Categories.FindAsync(idCategory);
    }
    #endregion

    #region GetCategoriesAsync
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.ToListAsync();
    }
    #endregion

    #region UpdateAsync
    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();

        return category;
    }
    #endregion

    #endregion
}
