
using MediatR;
using Microsoft.Extensions.Logging;
using StockApp.Domain.Event;

internal sealed class ProductCreatedDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    private readonly ILogger<ProductCreatedDomainEventHandler> _logger ;
    public ProductCreatedDomainEventHandler(ILogger<ProductCreatedDomainEventHandler> logger){
        _logger = logger;
    }
    public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"product created notification event of productId {notification.ProductId} ");

        // _logger.LogInformation(" creating stock ", notification.ProductId);

        await  Task.CompletedTask;
    }
}
