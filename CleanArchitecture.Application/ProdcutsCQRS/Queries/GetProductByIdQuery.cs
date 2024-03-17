using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.ProdcutsCQRS.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
