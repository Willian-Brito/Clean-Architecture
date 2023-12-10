
using AutoMapper;
using Core.Application.DTOs.Categories;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Interfaces;

namespace Core.Application.Services;

public class CategoryService : ICategoryService
{
    #region Propriedades da Classe
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Construtor
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    #endregion

    #region Metodos

    #region GetById
    public async Task<CategoryDTO> GetById(int? idCategory)
    {
        var categoryEntity = await _categoryRepository.GetByIdAsync(idCategory);
        var categoryDTO = _mapper.Map<CategoryDTO>(categoryEntity);

        return categoryDTO;
    }
    #endregion

    #region GetCategories
    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
        var categoryDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);

        return categoryDTO;
    }
    #endregion

    #region Add
    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.CreateAsync(categoryEntity);
        
        categoryDTO.IdCategory = categoryEntity.IdCategory;
    }
    #endregion

    #region Remove
    public async Task Remove(int? idCategory)
    {
        var categoryEntity = _categoryRepository.GetByIdAsync(idCategory).Result;
        await _categoryRepository.DeleteAsync(categoryEntity);
    }
    #endregion

    #region Update
    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.UpdateAsync(categoryEntity);
    }
    #endregion

    #endregion
}
