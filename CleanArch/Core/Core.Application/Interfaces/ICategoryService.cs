namespace Core.Application;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? idCategory);
    Task Add(CategoryDTO categoryDTO);
    Task Update(CategoryDTO categoryDTO);
    Task Remove(int? idCategory);
}
