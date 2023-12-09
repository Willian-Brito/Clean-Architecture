using Core.Application.DTOs.Categories;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WepApp.Controllers;

[Authorize]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    #region Construtor
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #endregion

    #region Actions

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategories();

        return View(categories);
    }
    #endregion

    #region Create
    
    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDTO category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.Add(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    #endregion

    #region Edit
    [HttpGet()]
    public async Task<IActionResult> Edit(int? idCategory)
    {
        if (idCategory == null) return NotFound();

        var categoryDTO = await _categoryService.GetById(idCategory);

        if(categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _categoryService.Update(categoryDTO);
            }
            catch(Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));

        }

        return View(categoryDTO);
    }
    #endregion
    
    #region Delete
    [HttpGet()]
    public async Task<IActionResult> Delete(int? idCategory)
    {
        if (idCategory == null) return NotFound();

        var categoryDTO = await _categoryService.GetById(idCategory);

        if(categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? idCategory)
    {
        await _categoryService.Remove(idCategory);
        return RedirectToAction("Index");
    }
    #endregion

    #region Details
    [HttpGet()]
    public async Task<IActionResult> Details(int? idCategory)
    {
        if (idCategory == null) return NotFound();

        var categoryDTO = await _categoryService.GetById(idCategory);

        if(categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }
    #endregion

    #endregion
}
