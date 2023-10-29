using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int? IdProduct { get; set; }

    public GetProductByIdQuery(int? idProduct)
    {
            IdProduct = idProduct;
    }
}
