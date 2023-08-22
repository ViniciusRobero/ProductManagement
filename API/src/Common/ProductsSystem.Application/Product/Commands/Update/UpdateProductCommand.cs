using System;
using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Common.Exceptions;
using ProductsSystem.Application.Common.Interfaces;
using ProductsSystem.Application.Common.Models;
using ProductsSystem.Application.Dto;
using ProductsSystem.Domain.Entities;
using MapsterMapper;

namespace ProductsSystem.Application.Products.Commands.Update
{
    public class UpdateProductCommand : IRequestWrapper<ProductDto>
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string ProductCode { get; set; }

        public string Discription { get; set; }

        public decimal Value { get; set; }

    }

    public class UpdateCandidateCommandHandler : IRequestHandlerWrapper<UpdateProductCommand, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCandidateCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            if (!string.IsNullOrEmpty(request.Brand))
                entity.Brand = request.Brand;

            if (!string.IsNullOrEmpty(request.ProductCode))
                entity.ProductCode = request.ProductCode;

            if (!string.IsNullOrEmpty(request.Discription))
                entity.Discription = request.Discription;
            
            entity.Value = request.Value;


            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<ProductDto>(entity));
        }
    }
}
