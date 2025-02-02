
using ErrorOr;
using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.CustomerQueries
{
    public record GetCustomerQuery(
        CustomerId CustomerId ) : IRequest<CustomerResponse>;

    public record GetAllCustomerQuery() : IRequest<List<CustomerResponse>>;

    public record CustomerResponse(
            Guid Id,
            string Name,
            string Email            
         );
}