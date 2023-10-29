using Core.Application.Products.Commands;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.IdProduct);

        if (product == null)
            throw new ApplicationException("Produto não encontrado!");

        product.Update(request.IdProduct, request.Name, request.Description, 
                       request.Price, request.Stock, request.Image, request.IdCategory);

        return await _productRepository.UpdateAsync(product);
    }
}
