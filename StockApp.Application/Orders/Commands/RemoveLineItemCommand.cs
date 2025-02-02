
using FluentResults;
using MediatR;
using StockApp.Domain.Entities;

namespace StockApp.Application.Command
{
    public record RemoveLineItemCommand(
         OrderId OrderId,
        LineItemId LineItemId
    ): IRequest<Result>;
}