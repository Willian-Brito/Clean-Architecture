using Core.Domain;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Products.Commands;

public abstract class ProductCommand : IRequest<Product>
{
    #region Propriedades da Classe
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Image { get; set; }
    public int IdCategory { get; set; }
    #endregion
}
