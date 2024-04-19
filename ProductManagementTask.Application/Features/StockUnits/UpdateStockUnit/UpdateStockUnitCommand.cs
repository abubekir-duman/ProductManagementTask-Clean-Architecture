using MediatR;

namespace ProductManagementTask.Application.Features.StockUnits.UpdateStockUnit;
public sealed record UpdateStockUnitCommand(
    int Id,
    bool IsActive,
    string Code,
    int StockTypeId,
    int QuantityUnitValue,
    string Description,
    decimal BuyingAmount,
    int BuyingCurrencyValue,
    decimal SellingAmount,
    int SellingCurrencyValue,
    int PaperWeight
    ) :IRequest;
