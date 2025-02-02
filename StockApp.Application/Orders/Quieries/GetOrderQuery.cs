

using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Queries
{
    public record GetOrderQuery() : IRequest<List<OrderResponse>>;

    public record GetOrderByIdQuery(OrderId OrderId) : IRequest<OrderResponse>;

    public record OrderResponse(
            Guid Id,
            string Product,
            string CustomerId,           
            string Currency,
            decimal Amount
    );
}