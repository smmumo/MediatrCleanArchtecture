

using Microsoft.EntityFrameworkCore;
using StockApp.Domain;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Repository;

internal sealed  class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
 
    private readonly ApplicationDbContext _context = context;

    public void Add(Order Order)
    {
       _context.Order.Add(Order);
    }

    public Task<List<Order>> GetAll()
    {
       return  _context.Order.ToListAsync();
        //throw new NotImplementedException();
    }

    // public async Task<Order?> GetByIdAsync(OrderId id)
    // {
    //     return await _context.
    // }

    public Task<Order?> GetByIdWithLineItemAsync(OrderId id , LineItemId lineItemId)
    {
        return _context.Order.Include(o => o.LineItemList.Where(li => li.Id == lineItemId))
                             .SingleOrDefaultAsync();
        //throw new NotImplementedException();
    }

    public void Remove(Order Order)
    {
         _context.Order.Remove(Order);
    }

    public void Update(Order Order)
    {
         _context.Order.Update(Order);
    }
}