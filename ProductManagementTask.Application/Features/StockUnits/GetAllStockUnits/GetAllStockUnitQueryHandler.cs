using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockUnits.GetAllStockUnits;

internal sealed class GetAllStockUnitQueryHandler(IStockUnitRepository stockUnitRepository) : IRequestHandler<GetAllStockUnitQuery, List<StockUnit>>
{
    public async Task<List<StockUnit>> Handle(GetAllStockUnitQuery request, CancellationToken cancellationToken)
    {
        List<StockUnit> stockUnits = await stockUnitRepository.GetAll().ToListAsync(cancellationToken);

        return stockUnits;
    }
}
