using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Application.Features.StockTypes.DeleteStockTypeByIdCommand;
public sealed record DeleteStockTypeByIdCommand(
    int Id):IRequest;
