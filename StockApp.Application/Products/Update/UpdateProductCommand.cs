using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Products.Create
{
    public record UpdateProductCommand(
        ProductId ProductId,
        string Name,
        string Sku,
        string Currency,
        decimal Amount
    ): IRequest;

     public record UpdateProductRequest(        
        string Name,
        string Sku,
        string Currency,
        decimal Amount
    );
}