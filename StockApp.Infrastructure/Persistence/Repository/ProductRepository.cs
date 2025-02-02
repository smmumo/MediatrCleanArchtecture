
using Microsoft.EntityFrameworkCore;
using StockApp.Domain;
using StockApp.Domain.Entities;
using StockApp.Domain.Products;

namespace StockApp.Infrastracture.Persistence.Repository;

internal sealed  class ProductRepository : IProductRepository
{
 
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context){
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Product.Add(product);
    }

    public Task<List<Product>> GetAll()
    {
        return  _context.Product.ToListAsync();
    }

    public Task<Product?> GetByIdAsync(ProductId id)
    {
        return  _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public void Remove(Product product)
    {
          _context.Product.Remove(product);
    }

    public void Update(Product product)
    {
         _context.Product.Update(product);
    }
}