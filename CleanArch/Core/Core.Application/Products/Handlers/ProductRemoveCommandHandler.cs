using Core.Application.Products.Commands;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.IdProduct);

        if (product == null)
            throw new ApplicationException("Produto não encontrado!");

        return await _productRepository.DeleteAsync(product);
    }
}
