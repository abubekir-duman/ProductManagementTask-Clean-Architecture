using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockUnits.DeleteStockUnitById;

internal sealed class DeleteStockUnitByIdCommandHandler(IStockUnitRepository stockUnitRepository,IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockUnitByIdCommand>
{
    public async Task Handle(DeleteStockUnitByIdCommand request, CancellationToken cancellationToken)
    {
        StockUnit stockUnit = await stockUnitRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (stockUnit is null)
        {
            throw new ArgumentException("Stok unit bulunamadı");
        }

        stockUnitRepository.Delete(stockUnit);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
    }
}
