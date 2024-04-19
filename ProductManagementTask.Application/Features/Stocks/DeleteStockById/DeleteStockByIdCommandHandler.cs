using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.Stocks.DeleteStockById;

internal sealed class DeleteStockByIdCommandHandler(IStockRepository stockRepository,IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockByIdCommand>
{
    public async Task Handle(DeleteStockByIdCommand request, CancellationToken cancellationToken)
    {
        Stock stock=await stockRepository.GetByExpressionAsync(p=>p.Id==request.Id,cancellationToken);
        if(stock is null)
        {
            throw new ArgumentException("Stok bulunamadı");
        }

        stockRepository.Delete(stock);
        await unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
