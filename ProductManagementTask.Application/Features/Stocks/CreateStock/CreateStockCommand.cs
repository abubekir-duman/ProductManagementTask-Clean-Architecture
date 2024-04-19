using MediatR;

namespace ProductManagementTask.Application.Features.Stocks.CreateStock;
public sealed record CreateStockCommand(
    int StockTypeId,
    int StockUnitId,
    int StockClassValue,
    int Quantity,
    string ShelfInformation,
    string CabinetInformation,
    int CriticalQuantity):IRequest;

