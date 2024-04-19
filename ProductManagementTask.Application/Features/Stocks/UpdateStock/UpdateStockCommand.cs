using MediatR;

namespace ProductManagementTask.Application.Features.Stocks.UpdateStock;
public sealed record UpdateStockCommand(
     int StockTypeId,
    int StockUnitId,
    int StockClassValue,
    int Id,
    bool IsActive,
    int Quantity,
    string ShelfInformation,
    string CabinetInformation,
    int CriticalQuantity
    ) :IRequest;
