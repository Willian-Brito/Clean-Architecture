
using AutoMapper;
using MediatR;
using Core.Application.DTOs.Products;
using Core.Application.Interfaces;
using Core.Application.Products.Commands;
using Core.Application.Products.Queries;

namespace Core.Application.Services;

public class ProductService : IProductService
{
    #region Propriedades da Classe
    private IMediator _mediator;
    private IMapper _mapper;
    #endregion

    #region Construtor
    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    #endregion

    #region Metodos

    #region Queries

    #region GetById
    public async Task<ProductDTO> GetById(int? idProduct)
    {
        var productByIdQuery = new GetProductByIdQuery(idProduct);

        if (productByIdQuery == null)
            throw new ApplicationException("Produto não pode ser carregado!");

        var result = await _mediator.Send(productByIdQuery);
        var productDTO = _mapper.Map<ProductDTO>(result);

        return productDTO;
    }
    #endregion

    #region GetProducts
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productQuery = new GetProductQuery();

        if (productQuery == null)
            throw new ApplicationException("Produto não pode ser carregado!");

        var result = await _mediator.Send(productQuery);
        var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(result);

        return productDTO;
    }
    #endregion

    #region GetProductCategory
    // public async Task<ProductDTO> GetProductCategory(int idProduct)
    // {
    //     var productByIdQuery = new GetProductByIdQuery(idProduct);

    //     if (productByIdQuery == null)
    //         throw new ApplicationException("Produto não pode ser carregado!");

        
    //     var result = await _mediator.Send(productByIdQuery);
    //     var productDTO = _mapper.Map<ProductDTO>(result);

    //     return productDTO;
    // }
    #endregion

    #endregion

    #region Commands

    #region Add
    public async Task Add(ProductDTO productDTO)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
        await _mediator.Send(productCreateCommand);
    }
    #endregion

    #region Remove
    public async Task Remove(int? idProduct)
    {
        var productRemoveCommand = new ProductRemoveCommand(idProduct);

        if(productRemoveCommand == null)
            throw new ApplicationException("Produto não pode ser carregado!");
        
        await _mediator.Send(productRemoveCommand);
    }
    #endregion

    #region Update
    public async Task Update(ProductDTO productDTO)
    {
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
        await _mediator.Send(productUpdateCommand);
    }
    #endregion

    #endregion
    
    #endregion
}
