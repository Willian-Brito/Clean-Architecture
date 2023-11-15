using Core.Application.Products.Commands;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.Handlers;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductCreateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

        if (product == null)
            throw new ApplicationException("Erro ao criar produto!");
            
        product.IdCategory = request.IdCategory;
        return await _productRepository.CreateAsync(product);
    }
}
