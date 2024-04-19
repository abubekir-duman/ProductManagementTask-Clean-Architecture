using MediatR;
using ProductManagementTask.Domain.Entities;

namespace ProductManagementTask.Application.Features.StockUnits.GetAllStockUnits;
public sealed record GetAllStockUnitQuery(
   ):IRequest<List<StockUnit>>;
