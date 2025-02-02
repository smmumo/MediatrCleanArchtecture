using MediatR;

namespace StockApp.Application.CreateCustomer
{
    public record CreateCustomerCommand(
        string Name,      
        string Email       
    ): IRequest;
}