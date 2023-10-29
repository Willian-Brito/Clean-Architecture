using Core.Application.Products.Queries;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using MediatR;

namespace Core.Application.Handlers;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;        
    }

    public Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var products = _productRepository.GetProductsAsync();
        return products;
    }
}
