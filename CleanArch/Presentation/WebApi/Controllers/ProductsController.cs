using Core.Application.DTOs.Products;
using Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    #region Construtor
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    #endregion

    #region Actions

    #region Get
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var products = await _productService.GetProducts();

        if(products == null)
            return BadRequest("Não foi possível encontrar os Produtos!");

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var product = await _productService.GetById(id);

        if(product == null)
            return BadRequest("Produto não existe!");

        return Ok(product);
    }
    #endregion

    #region Post
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
    {
        if(productDTO == null)
            return BadRequest("Dados Inválidos");

        await _productService.Add(productDTO);

        return new CreatedAtRouteResult("GetProduct", new {id = productDTO.IdProduct}, productDTO);
    }
    #endregion

    #region Put
    [HttpPut]
    public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody] ProductDTO productDTO)
    {
        if(id != productDTO.IdProduct)
            return BadRequest("O ID do parâmetro da requisição não corresponde ao ID do produto do corpo da requisição!");

        if(productDTO == null)
            return BadRequest("Dados do Produto Inválido!");

        await _productService.Update(productDTO);

        return Ok(productDTO);
    }
    #endregion

    #region Delete
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var productDTO = await _productService.GetById(id);

        if(productDTO == null)
            return NotFound("Produto não existe");

        await _productService.Remove(id);

        return Ok("Produto removido com sucesso!");
    }
    #endregion

    #endregion
}
