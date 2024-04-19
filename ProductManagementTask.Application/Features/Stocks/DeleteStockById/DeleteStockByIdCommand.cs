using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementTask.Application.Features.Stocks.DeleteStockById;
public sealed record DeleteStockByIdCommand(
    int Id
 ):IRequest;
