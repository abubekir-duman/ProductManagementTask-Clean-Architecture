using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockUnits.CreateStockUnit;

internal sealed class CreateStockUnitCommandHandler(IStockUnitRepository stockUnitRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreateStockUnitCommand>
{
    public async Task Handle(CreateStockUnitCommand request, CancellationToken cancellationToken)
    {
        bool isStockUnitExists = await stockUnitRepository.AnyAsync(p => p.Code == request.Code, cancellationToken);
        if (isStockUnitExists)
        {
            throw new ArgumentException("Code daha önceden oluşturulmuş");
        }

        StockUnit stockUnit = new()
        {
            Code = request.Code,
            StockTypeId = request.StockTypeId,
            Description = request.Description,
            QuantityUnit = QuantityUnitEnum.FromValue(request.QuantityUnitValue),
            Buying=new(request.BuyingAmount,MoneyTypeEnum.FromValue(request.BuyingCurrencyValue)),
            Selling=new(request.SellingAmount,MoneyTypeEnum.FromValue(request.SellingCurrencyValue)),
            PaperWeight=request.PaperWeight,
        };

        await stockUnitRepository.AddAsync(stockUnit, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
 