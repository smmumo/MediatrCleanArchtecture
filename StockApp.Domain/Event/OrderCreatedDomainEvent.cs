
using StockApp.Domain.Entities;

namespace StockApp.Domain.Event;

public record OrderCreatedDomainEvent(Guid Id ,OrderId OrderId) : DomainEvent(Id) ;