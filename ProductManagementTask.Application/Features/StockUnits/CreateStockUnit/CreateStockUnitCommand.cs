using MediatR;

namespace ProductManagementTask.Application.Features.StockUnits.CreateStockUnit;
public sealed record CreateStockUnitCommand(
    string Code,
    int StockTypeId,
    int QuantityUnitValue,
    string Description,
    decimal BuyingAmount,
    int BuyingCurrencyValue,
    decimal SellingAmount,
    int SellingCurrencyValue,
    int PaperWeight
    ):IRequest;
 