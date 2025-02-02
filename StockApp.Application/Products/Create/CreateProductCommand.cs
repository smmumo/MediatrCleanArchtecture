
using MediatR;

namespace StockApp.Application.Products.Create
{
    public record CreateProductCommand(
        string Name,      
        string Currency,
        decimal Amount
    ): IRequest;
}