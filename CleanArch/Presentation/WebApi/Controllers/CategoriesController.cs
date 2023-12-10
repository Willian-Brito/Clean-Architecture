using Core.Application.DTOs.Categories;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    #region Construtor
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #endregion

    #region Actions

    #region Get
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categories  = await _categoryService.GetCategories();

        if  (categories == null)
            return NotFound("Não foi possível encontrar as categorias");

        return Ok(categories);        
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var category  = await _categoryService.GetById(id);

        if  (category == null)
            return NotFound("Categoria não existe!");

        return Ok(category);        
    }
    #endregion

    #region Post
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if(categoryDTO == null)
            return BadRequest("Dados Inválidos");

        await _categoryService.Add(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new {id = categoryDTO.IdCategory}, categoryDTO);
    }
    #endregion

    #region Put
    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if(id != categoryDTO.IdCategory)
            return BadRequest("O ID do parâmetro da requisição não corresponde ao ID da categoria do corpo da requisição");

        if(categoryDTO == null)
            return BadRequest("Dados da Categoria Inválido!");

        await _categoryService.Update(categoryDTO);

        return Ok(categoryDTO);
    }
    #endregion

    #region Delete
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoryDTO  = await _categoryService.GetById(id);

        if  (categoryDTO == null)
            return NotFound("Categoria não existe!");

        await _categoryService.Remove(id);

        return Ok("Categoria removida com sucesso!");
    }
    #endregion

    #endregion
}
