using Core.Application.DTOs.Categories;

namespace Core.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? idCategory);
    Task Add(CategoryCreateDTO categoryDTO);
    Task Update(CategoryDTO categoryDTO);
    Task Remove(int? idCategory);
}
