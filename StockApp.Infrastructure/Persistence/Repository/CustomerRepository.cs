
using Microsoft.EntityFrameworkCore;
using StockApp.Domain;
using StockApp.Domain.Entities;
using StockApp.Infrastracture.Persistence;

internal sealed  class CustomerRepository : ICustomerRepository
{
 
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context){
        _context = context;
    }

    public void Add(Customer customer)
    {
        _context.Customer.Add(customer);
    }

    public Task<List<Customer>> GetAll()
    {
       return _context.Customer.ToListAsync();
    }

    public void Remove(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}