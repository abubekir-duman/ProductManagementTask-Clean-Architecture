using MediatR;
using ProductManagementTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Application.Features.StockTypes.GetAllStockTypes;
public sealed record GetAllStockTypesQuery():IRequest<List<StockType>>;
