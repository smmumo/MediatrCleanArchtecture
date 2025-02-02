
using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Products.Delete
{
    public record DeleteProductCommand(
        ProductId ProductId ): IRequest;
}