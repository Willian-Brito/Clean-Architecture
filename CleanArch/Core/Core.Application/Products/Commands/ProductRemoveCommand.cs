using Core.Domain;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Products.Commands;

public class ProductRemoveCommand : IRequest<Product>
{
    public int? IdProduct { get; set; }

    public ProductRemoveCommand(int? idProduct)
    {
        IdProduct = idProduct;
    }
}
