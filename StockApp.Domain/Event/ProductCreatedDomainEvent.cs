using StockApp.Domain.Entities;

namespace StockApp.Domain.Event;

public record ProductCreatedDomainEvent(Guid Id ,ProductId ProductId) : DomainEvent(Id) ;