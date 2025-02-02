
using MediatR;

namespace StockApp.Domain.Event;

public record DomainEvent(Guid Id) : INotification;