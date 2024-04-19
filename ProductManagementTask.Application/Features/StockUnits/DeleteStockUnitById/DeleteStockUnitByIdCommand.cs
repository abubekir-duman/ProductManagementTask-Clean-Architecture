using MediatR;

namespace ProductManagementTask.Application.Features.StockUnits.DeleteStockUnitById;
public sealed record DeleteStockUnitByIdCommand(
    int Id
    ):IRequest;
