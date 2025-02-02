
using StockApp.Domain.Entities;

namespace StockApp.Domain;

public interface ICustomerRepository {
    //Task<Order?> GetByIdWithLineItemAsync(OrderId id , LineItemId lineItemId); 
    void Add(Customer customer);
    void Remove(Customer customer);
    void Update(Customer customer);
     Task<List<Customer>> GetAll();
}