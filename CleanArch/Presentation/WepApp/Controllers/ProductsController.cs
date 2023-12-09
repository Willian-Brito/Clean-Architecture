using Core.Application.DTOs.Products;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WepApp.Controllers;

public class ProductsController : Controller
{
    #region Propriedades da Classe
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IWebHostEnvironment _environment;
    #endregion

    #region Construtor
    public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment environment)
    {
        _productService = productService;
        _categoryService = categoryService;
        _environment = environment;
    }
    #endregion

    #region Actions

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }
    #endregion

    #region Create

    [HttpGet()]
    public async Task<ActionResult> Create()
    {
        var categories = await _categoryService.GetCategories();
        ViewBag.IdCategory = new SelectList(categories, "IdCategory", "Name");

        return View();
    }

    [HttpPost()]
    public async Task<ActionResult> Create(ProductDTO productDTO)
    {
        if(ModelState.IsValid)
        {
            await _productService.Add(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }
    #endregion

    #region Edit

    [HttpGet()]
    public async Task<IActionResult> Edit(int? idProduct)
    {
        if (idProduct == null) return NotFound();

        var productDTO = await _productService.GetById(idProduct);

        if(productDTO == null) return NotFound();

        var categories = await _categoryService.GetCategories();
        ViewBag.IdCategory = new SelectList(categories, "IdCategory", "Name", productDTO.IdCategory);

        return View(productDTO);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        if(ModelState.IsValid)
        {
            await _productService.Update(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }
    #endregion

    #region Delete

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(int? idProduct)
    {
        if (idProduct == null) return NotFound();

        var productDTO =  await _productService.GetById(idProduct);

        if (productDTO == null) return NotFound();

        return View(productDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? idProduct)
    {
        await _productService.Remove(idProduct);
        return RedirectToAction("Index");
    }   
    #endregion

    #region Details

    [HttpGet()]
    public async Task<IActionResult> Details(int? idProduct)
    {
        if(idProduct == null) return NotFound();

        var productDTO = await _productService.GetById(idProduct);

        if(productDTO == null) return NotFound();

        var path = _environment.WebRootPath;
        var image = Path.Combine(path,$"images/{productDTO.Image}");
        var exists = System.IO.File.Exists(image);

        ViewBag.ImageExist = exists;

        return View(productDTO);
    }
    #endregion
    
    #endregion
}
