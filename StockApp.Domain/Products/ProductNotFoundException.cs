using StockApp.Domain.Entities;

namespace StockApp.Domain.Products;

public sealed class ProductNotFoundException : Exception {

    public ProductNotFoundException(ProductId Id) : base($" Product with ID = {Id.Value} was not found") {
        
    }

}