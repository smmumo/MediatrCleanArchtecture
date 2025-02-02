
using Microsoft.EntityFrameworkCore;
using StockApp.Domain;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Repository;

internal sealed class UnitOfWorkRepository(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result;
    }
}