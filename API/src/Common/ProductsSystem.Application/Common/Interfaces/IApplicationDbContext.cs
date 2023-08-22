using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductsSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
