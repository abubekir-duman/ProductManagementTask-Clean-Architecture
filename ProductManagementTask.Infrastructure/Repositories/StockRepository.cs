using GenericRepository;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;
using ProductManagementTask.Infrastructure.Context;

namespace ProductManagementTask.Infrastructure.Repositories;
internal sealed class StockRepository : Repository<Stock, ApplicationDbContext>, IStockRepository
{
    public StockRepository(ApplicationDbContext context) : base(context)
    {
    }
}
