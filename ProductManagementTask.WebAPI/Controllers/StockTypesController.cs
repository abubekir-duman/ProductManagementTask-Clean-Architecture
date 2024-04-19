using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementTask.Application.Features.Stocks.CreateStock;
using ProductManagementTask.Application.Features.Stocks.DeleteStockById;
using ProductManagementTask.Application.Features.Stocks.GetAllStock;
using ProductManagementTask.Application.Features.Stocks.UpdateStock;
using ProductManagementTask.Application.Features.StockTypes.CreateStockType;
using ProductManagementTask.Application.Features.StockTypes.DeleteStockTypeByIdCommand;
using ProductManagementTask.Application.Features.StockTypes.GetAllStockTypes;
using ProductManagementTask.Application.Features.StockTypes.UpdateStockType;
using ProductManagementTask.Domain.Entities;

namespace ProductManagementTask.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StockTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<StockType> stockTypes = await mediator.Send(new GetAllStockTypesQuery(), cancellationToken);

        return Ok(stockTypes);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStockTypeCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateStockTypeCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();


    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteStockTypeByIdCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}
