using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.ProdcutsCQRS.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public ProductRemoveCommand(int id)
        {
                Id = id;
        }

        public int Id { get; set; }
    }
}
