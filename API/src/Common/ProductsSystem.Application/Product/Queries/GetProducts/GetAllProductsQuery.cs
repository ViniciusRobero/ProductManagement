using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Common.Interfaces;
using ProductsSystem.Application.Common.Models;
using ProductsSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductsSystem.Application.Products.Queries.GetProducts
{
    public class GetAllProductsQuery : IRequestWrapper<List<ProductDto>>
    {

    }

    public class GetProductsQueryHandler : IRequestHandlerWrapper<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<ProductDto> list = await _context.Products
                .ProjectToType<ProductDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<ProductDto>>(ServiceError.NotFound);
        }
    }
}
