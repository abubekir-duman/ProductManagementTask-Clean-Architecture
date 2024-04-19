using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementTask.Application.Features.Stocks.CreateStock;
using ProductManagementTask.Application.Features.Stocks.DeleteStockById;
using ProductManagementTask.Application.Features.Stocks.GetAllStock;
using ProductManagementTask.Application.Features.Stocks.UpdateStock;
using ProductManagementTask.Application.Features.StockUnits.CreateStockUnit;
using ProductManagementTask.Application.Features.StockUnits.DeleteStockUnitById;
using ProductManagementTask.Application.Features.StockUnits.GetAllStockUnits;
using ProductManagementTask.Application.Features.StockUnits.UpdateStockUnit;
using ProductManagementTask.Domain.Entities;

namespace ProductManagementTask.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StockUnitsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<StockUnit> stockUnits = await mediator.Send(new GetAllStockUnitQuery(), cancellationToken);

        return Ok(stockUnits);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStockUnitCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateStockUnitCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();


    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteStockUnitByIdCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}
