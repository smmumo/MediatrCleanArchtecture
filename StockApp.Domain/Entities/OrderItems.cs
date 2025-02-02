


using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.Domain.Entities;

public class LineItems : Entity  { //: Entity<LineItemId> 

    public  LineItemId Id {get ; private set;} = null! ;
    
    public ProductId ProductId {get ; private set;} = null! ;
    public Money Price {get ; private set;}  = null! ;

    public OrderId OrderId {get ; private set;}     
    public Order Order {get ; private set;}  = null! ;

    // public LineItems(LineItemId lineItemId) : base(lineItemId){}

    private  LineItems( 
            LineItemId lineItemId,
            OrderId orderId,ProductId productIds, Money prices) 
    {    
        Id = lineItemId ;   
        ProductId = productIds ;
        Price = prices;
        OrderId = orderId;
    }

    public LineItems() {}
   
    public static LineItems Create(OrderId orderId,ProductId productIds, Money prices)
    {
        var lineitems = new LineItems(  
                            new LineItemId(Guid.NewGuid()),                  
                            orderId,
                            productIds,
                            prices
                    );

            // var r = new LineItems();
        return lineitems;
    }


}

public record LineItemId(Guid Value);



//public record OrderItemId(Guid Value);