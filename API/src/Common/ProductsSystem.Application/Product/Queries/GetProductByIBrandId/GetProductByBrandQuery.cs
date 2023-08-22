using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Common.Interfaces;
using ProductsSystem.Application.Common.Models;
using ProductsSystem.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductsSystem.Application.Products.Queries.GetProductByIBrandId
{
    public class GetProductByBrandQuery : IRequestWrapper<ProductDto>
    {
        public string Brand { get; set; }
    }

    public class GetProductByBrandQueryHandler : IRequestHandlerWrapper<GetProductByBrandQuery, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByBrandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ProductDto>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Products
                .Where(x => x.Brand.Contains(request.Brand))
                .ProjectToType<ProductDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return candidate != null ? ServiceResult.Success(candidate) : ServiceResult.Failed<ProductDto>(ServiceError.NotFound);
        }
    }
}
