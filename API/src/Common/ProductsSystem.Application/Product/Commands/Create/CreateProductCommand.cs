using System;
using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Common.Interfaces;
using ProductsSystem.Application.Common.Models;
using ProductsSystem.Application.Dto;
using ProductsSystem.Domain.Entities;
using MapsterMapper;

namespace ProductsSystem.Application.Products.Commands.Create
{
    public record CreateProductCommand(string Brand, string ProductCode, string Discription, double Value) : IRequestWrapper<ProductDto>;

    public class CreateProductCommandHandler : IRequestHandlerWrapper<CreateProductCommand, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Brand = request.Brand,
                Discription = request.Discription,
                ProductCode = request.ProductCode,
                Value = request.Value
            };

            await _context.Products.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ProductDto>(entity));
        }
    }
}
