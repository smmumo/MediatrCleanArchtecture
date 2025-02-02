
using StockApp.Domain.Entities;

namespace StockApp.Domain.Event;

public record LineItemRemovedDomainEvent(Guid Id ,OrderId OrderId , LineItemId LineItemId) : DomainEvent(Id) ;