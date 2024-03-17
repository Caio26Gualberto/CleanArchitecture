using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ProdcutsCQRS.Commands;
using CleanArchitecture.Application.ProdcutsCQRS.Queries;
using MediatR;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            if (productCreateCommand == null)
                throw new Exception("A entidade não foi carregada");

            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception("A entidade não foi carregada");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception("A entidade não foi carregada");

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(productsQuery);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new Exception("A entidade não foi carregada");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            if (productCreateCommand == null)
                throw new Exception("A entidade não foi carregada");

            await _mediator.Send(productCreateCommand);
        }
    }
}
