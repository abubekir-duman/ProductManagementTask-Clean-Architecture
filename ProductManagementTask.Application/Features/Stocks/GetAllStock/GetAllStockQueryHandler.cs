using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.Stocks.GetAllStock;

internal sealed class GetAllStockQueryHandler(IStockRepository stockRepository) : IRequestHandler<GetAllStockQuery,List<Stock>>
{
    public async Task<List<Stock>> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
    {
        List<Stock> stocks = await stockRepository.GetAll().ToListAsync();

        return stocks;
    }
}
