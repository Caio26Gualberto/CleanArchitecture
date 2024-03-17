using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.ProdcutsCQRS.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
