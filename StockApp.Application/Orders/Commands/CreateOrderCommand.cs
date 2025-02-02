
using FluentResults;
using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Command
{
    public record CreateOrderCommand(
             ProductId ProductId ,
             CustomerId CustomerId ,
             Money Price 
    ): IRequest<Result>;
}