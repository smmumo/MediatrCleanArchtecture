namespace StockApp.Domain.Entities;

public  class Customer {
    public CustomerId Id{ get; private set; }
    public string Email{ get; private set; }
    public string Name { get; private set; }

    private void ValidateCustomer()
    {
        if (string.IsNullOrEmpty(Email))
        {
            throw new ArgumentException("Email can not be empty");
        }
        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentException("Name can not be empty");
        }
    }

    public Customer(){}

    private Customer(string Emails,string Names){
        Id = new CustomerId(Guid.NewGuid()) ;
        Email = Emails;
        Name = Names;
    }

    public static Customer Create(string Emails,string Name){
        return new Customer(Emails,Name);
    }

}

public record CustomerId(Guid Value);
