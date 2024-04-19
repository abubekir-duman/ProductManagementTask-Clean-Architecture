using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.Stocks.CreateStock;

internal sealed class CreateStockCommandHandler(IStockRepository stockRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreateStockCommand>
{
    public async Task Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        Stock stock = new()
        {
            StockTypeId = request.StockTypeId,
            StockUnitId = request.StockUnitId,
            StockClass=StockClassEnum.FromValue(request.StockClassValue),
            Quantity = request.Quantity,
            ShelfInformation = request.ShelfInformation,
            CabinetInformation = request.CabinetInformation,
            CriticalQuantity = request.CriticalQuantity
        };

        await stockRepository.AddAsync(stock,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

