
namespace StockApp.Domain.DbContext;

public interface IUnitOfWork
{
   Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

