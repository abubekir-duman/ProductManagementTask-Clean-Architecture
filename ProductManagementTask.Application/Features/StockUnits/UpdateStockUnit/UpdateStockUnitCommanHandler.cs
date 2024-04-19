using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockUnits.UpdateStockUnit;

internal sealed class UpdateStockUnitCommanHandler(IStockUnitRepository stockUnitRepository,IUnitOfWork unitOfWork) : IRequestHandler<UpdateStockUnitCommand>
{
    public async Task Handle(UpdateStockUnitCommand request, CancellationToken cancellationToken)
    {
        StockUnit stockUnit = await stockUnitRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id,cancellationToken);
        if (stockUnit is null)
        {
            throw new ArgumentException("Stok unit daha önceden kaydedilmiş");
        }

        stockUnit.QuantityUnit = QuantityUnitEnum.FromValue(request.QuantityUnitValue);
        stockUnit.PaperWeight=request.PaperWeight;
        stockUnit.Buying = new(request.BuyingAmount, MoneyTypeEnum.FromValue(request.BuyingCurrencyValue));
        stockUnit.Selling = new(request.SellingAmount, MoneyTypeEnum.FromValue(request.SellingCurrencyValue));
        stockUnit.Description = request.Description;
        stockUnit.Code = request.Code;
        stockUnit.IsActive = request.IsActive;
        stockUnit.StockTypeId=request.StockTypeId;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
