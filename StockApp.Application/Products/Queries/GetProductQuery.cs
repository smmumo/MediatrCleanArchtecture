

using ErrorOr;
using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Products.Queries
{
    public record GetProductQuery(
        ProductId ProductId ) : IRequest<ProductResponse>;

   public record GetAllProductQuery() : IRequest<List<ProductResponse>>;

    public record ProductResponse(
            Guid Id,
            string Name,
            string Sku,
            string Currency,
            decimal Amount
         );
}