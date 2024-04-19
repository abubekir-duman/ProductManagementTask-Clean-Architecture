using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.Stocks.UpdateStock;

internal sealed class UpdateStockCommandHandler(IStockRepository stockRepository,IUnitOfWork unitOfWork) : IRequestHandler<UpdateStockCommand>
{
    public async Task Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        Stock stock = await stockRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id,cancellationToken);
        if(stock is null)
        {
            throw new ArgumentException("Stok bulunamadı");
        }
        stock.StockUnitId = request.StockUnitId;
        stock.StockTypeId= request.StockTypeId;
        stock.StockClass = StockClassEnum.FromValue(request.StockClassValue);
        stock.Quantity = request.Quantity;
        stock.CriticalQuantity = request.CriticalQuantity;
        stock.CabinetInformation= request.CabinetInformation;
        stock.ShelfInformation= request.ShelfInformation;
        stock.IsActive= request.IsActive;
        

         //stockRepository.Update(stock); üste tracking varsa update metoduna gerek yok.
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
