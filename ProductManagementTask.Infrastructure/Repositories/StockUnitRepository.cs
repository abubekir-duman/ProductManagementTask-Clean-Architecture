using GenericRepository;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;
using ProductManagementTask.Infrastructure.Context;

namespace ProductManagementTask.Infrastructure.Repositories;
internal sealed class StockUnitRepository : Repository<StockUnit, ApplicationDbContext>, IStockUnitRepository
{
    public StockUnitRepository(ApplicationDbContext context) : base(context)
    {
    }
}
