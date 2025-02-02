
using MediatR;
using StockApp.Domain.Event;

internal sealed class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
{
    public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("order created notification event of id ", notification.OrderId);
        await  Task.CompletedTask;
        //throw new NotImplementedException();
    }
}
