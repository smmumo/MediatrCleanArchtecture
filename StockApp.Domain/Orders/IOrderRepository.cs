
using StockApp.Domain.Entities;

namespace StockApp.Domain;

public interface IOrderRepository {
    Task<Order?> GetByIdWithLineItemAsync(OrderId id , LineItemId lineItemId); 
    void Add(Order Order);
    void Remove(Order Order);
    void Update(Order Order);
     Task<List<Order>> GetAll();
}