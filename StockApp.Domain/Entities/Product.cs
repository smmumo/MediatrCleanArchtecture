

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using StockApp.Domain.Event;

namespace StockApp.Domain.Entities;

public  class Product { 
    public ProductId Id { get; private set; }
    public string Name { get; private set; }
    public Money Price { get; private  set; }
    public Sku Sku{ get; private set; }
    //public Money money{ get; private set; }

     public Product(){}

    public Product(ProductId id, string name,Money Prices, Sku Skus){       
        // if(string.IsNullOrEmpty(name)){
        //     throw new ArgumentNullException($"{nameof(Name)} can not null or empty");
        // }     
        Id = id;
        Name = name;
        Price = Prices;
        Sku = Skus;
    }

     public static Product Create(string Name,string Currency,decimal Amount){

        var product = new Product(
                new ProductId(Guid.NewGuid()),
                Name,
                new Money(Currency,Amount),
                Sku.Create(Guid.NewGuid().ToString())!
            );

            //create event
            //product.Raise(new ProductCreatedDomainEvent(Guid.NewGuid(),product.Id));

            return product;                 
     }

     public void Validate(){
        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentNullException($"{nameof(Name)} is mandatory");
        }
        
        if (Price.Amount  == 0)
        {
            throw new ArgumentNullException($"{nameof(Price.Amount)} is mandatory");
        }
     }

    public void Update(string name , Money price , Sku sku){
        Name = name;
        Price = price ;
        Sku = sku;
    }
}

public record Money(string Currency , decimal Amount);

//Stock keeping Unit
public record Sku{
    private const int DefaultLength = 8 ;
    private Sku(string value) => Value = value ;

    public string Value { get; init ; }

    public static Sku? Create(string value){
        if(string.IsNullOrEmpty(value)){
            return null;
        }
        // if(value.Length != DefaultLength){
        //     return null;
        // }
        return new Sku(value);
    }

}


[NotMapped]
public record ProductId(Guid Value);
