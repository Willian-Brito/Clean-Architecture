
using AutoMapper;
using Core.Domain;
using Microsoft.VisualBasic;

namespace Core.Application;

public class ProductService : IProductService
{
    #region Propriedades da Classe
    private IProductRepository _productRepository;
    private IMapper _mapper;
    #endregion

    #region Construtor
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        _mapper = mapper;
    }
    #endregion

    #region Metodos

    #region GetById
    public async Task<ProductDTO> GetById(int? idProduct)
    {
        var productEntity = await _productRepository.GetByIdAsync(idProduct);
        var productDTO = _mapper.Map<ProductDTO>(productEntity);

        return productDTO;
    }
    #endregion

    #region GetProducts
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetProductsAsync();
        var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

        return productDTO;
    }
    #endregion

    #region GetProductCategory
    public async Task<ProductDTO> GetProductCategory(int idProduct)
    {
        var productEntity = await _productRepository.GetProductByCategoryAsync(idProduct);
        var productDTO = _mapper.Map<ProductDTO>(productEntity);
    
        return productDTO;
    }
    #endregion

    #region Add
    public async Task Add(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.CreateAsync(productEntity);
    }
    #endregion

    #region Remove
    public async Task Remove(int? idProduct)
    {
        var productEntity = _productRepository.GetByIdAsync(idProduct).Result;
        await _productRepository.DeleteAsync(productEntity);
    }
    #endregion

    #region Update
    public async Task Update(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.UpdateAsync(productEntity);
    }
    #endregion

    #endregion
}
