using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;

namespace ProductManagementTask.Application.Features.Stocks.GetAllStock;
public sealed record GetAllStockQuery(
    ):IRequest<List<Stock>>;
