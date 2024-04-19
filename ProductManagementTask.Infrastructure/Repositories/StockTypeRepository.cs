using GenericRepository;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;
using ProductManagementTask.Infrastructure.Context;

namespace ProductManagementTask.Infrastructure.Repositories;
internal sealed class StockTypeRepository : Repository<StockType, ApplicationDbContext>, IStockTypeRepository
{
    public StockTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
