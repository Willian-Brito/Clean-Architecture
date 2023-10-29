using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Products.Queries;

public class GetProductQuery : IRequest<IEnumerable<Product>>
{

}
