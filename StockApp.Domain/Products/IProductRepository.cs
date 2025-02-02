
using StockApp.Domain.Entities;

namespace StockApp.Domain.Products;

public interface IProductRepository {
    Task<Product?> GetByIdAsync(ProductId id);
    void Add(Product product);
    void Remove(Product product);
    void Update(Product product);
    Task<List<Product>> GetAll();
}