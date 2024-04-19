using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Application.Features.Stocks.CreateStock;
using ProductManagementTask.Application.Features.Stocks.DeleteStockById;
using ProductManagementTask.Application.Features.Stocks.GetAllStock;
using ProductManagementTask.Application.Features.Stocks.UpdateStock;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class StocksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<Stock> stocks = await mediator.Send(new GetAllStockQuery(), cancellationToken);

        return Ok(stocks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStockCommand request, CancellationToken cancellationToken)
    {
       await mediator.Send(request, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();

      
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteStockByIdCommand request,CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}

