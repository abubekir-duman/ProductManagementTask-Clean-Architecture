using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockTypes.GetAllStockTypes;

internal sealed class GetAllStockTypesQueryHandler
    (IStockTypeRepository stockTypeRepository,IUnitOfWork unitOfWork) : IRequestHandler<GetAllStockTypesQuery, List<StockType>>
{
    public async Task<List<StockType>> Handle(GetAllStockTypesQuery request, CancellationToken cancellationToken)
    {
        List<StockType> stockTypes = await stockTypeRepository.GetAll().ToListAsync(cancellationToken);
         
        return stockTypes;
    }
}
