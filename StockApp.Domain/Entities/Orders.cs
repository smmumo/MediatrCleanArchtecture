


using System.ComponentModel.DataAnnotations.Schema;
using StockApp.Domain.Event;

namespace StockApp.Domain.Entities;

public  class Order  : Entity, IAggregateRoot  {    //: AggregateRoot<OrderId>

    //https://medium.com/@iamprovidence/ef-configurations-are-sick-and-work-great-with-ddd-985ab3caec3f

    //https://medium.com/@nirajranasinghe/implement-value-objects-with-domain-driven-design-ddd-3aeb4e88cee5

    //https://github.com/dotnet/eShop/blob/main/src/Ordering.Domain/SeedWork/Entity.cs
    public  OrderId Id {get ; private set;} = null! ;
    public ProductId ProductId {get ; private set;} = null! ;
    public CustomerId CustomerId {get ; private set;} = null! ;
    public Money Price {get ; private set;} = null! ;

    private readonly List<LineItems> _lineItems = [];

    //[NotMapped]
    public IReadOnlyList<LineItems> LineItemList => _lineItems.AsReadOnly();

    private Order(OrderId orderId,CustomerId customerId,ProductId productId,Money price)  {
        ProductId = productId ;
        Price = price ;
        Id = orderId ;
        CustomerId = customerId  ;
    }

   // public Order(OrderId orderId) :base(orderId){}

    public Order(){}

    public static Order Create(CustomerId customerId,ProductId productId,Money price){
        var order = new Order(
             new OrderId(Guid.NewGuid()) ,
             customerId,
             productId,
             price
        ){
            // Id = new OrderId(Guid.NewGuid()) ,
            // CustomerId = customerId ,
            // ProductId = productId ,//new ProductId(Guid.NewGuid()),
            // Price = price , // new Money(Guid.NewGuid())
         };

        //create event
        // order.Raise(new OrderCreatedDomainEvent(Guid.NewGuid(),order.Id));

        return order;

    }

     public void  AddItems(LineItems lineitem){ //OrderId orderId, ProductId productId,  Money price
           // var lineitems = LineItems.Create(orderId,productId,price);
            _lineItems.Add(lineitem);
     }

    public void RemoveLineItems(LineItemId lineItemId){
        var lineitems = _lineItems.FirstOrDefault(li => li.Id == lineItemId);
        if(lineitems is null)
        {
            return ;
        }
        _lineItems.Remove(lineitems);

       // Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(),Id,lineItemId));
     }
}

public record OrderId(Guid Value);

