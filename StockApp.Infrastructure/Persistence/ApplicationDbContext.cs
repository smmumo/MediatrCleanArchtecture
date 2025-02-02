
using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;
using StockApp.Infrastracture.Persistence.Configuration;


namespace StockApp.Infrastracture.Persistence;

public  class ApplicationDbContext : DbContext //, IUnitOfWork
{

    public ApplicationDbContext(){}
    //private readonly IPublisher _publisher ;
    //public ApplicationDbContext(
      //  IPublisher publisher
    //)
    //{
      // _publisher = publisher;
    //}  

     public virtual DbSet<Product> Product { get; set; } = null!;   
     public virtual DbSet<Order> Order { get; set; } = null!; 
     public virtual DbSet<Customer> Customer { get; set; } = null!;
    //public virtual DbSet<LineItems> LineItems { get; set; } = null!;   

    // public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    // {
    //     var result = await base.SaveChangesAsync(cancellationToken);

    //     var domainEvent = ChangeTracker.Entries<Entity>().Select(e => e.Entity)
    //             .Where(e => e.DomainEvents.Any())
    //             .SelectMany(e => e.DomainEvents);

    //     foreach (var domainItemEnvent in domainEvent)
    //     {
    //         await _publisher.Publish(domainItemEnvent);
    //     }
    //     return result ;
    // }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            // if (!optionsBuilder.IsConfigured)
            // {
               // var connectionString = "server=127.0.0.1; port=3306; database=stockapp_db; user=stockapp_dev; password=7Ja5q0JLM6me-+*61;Convert Zero Datetime=True";
                var connectionString = "server=127.0.0.1;user=learn_dev;password=7Ja5q0JLM6me-+*61;database=learndotnet";

                var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

               optionsBuilder.UseMySql(connectionString, serverVersion)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors() ;
                    
                //  optionsBuilder.UseMySql(connectionString,
                //  ServerVersion.AutoDetect(connectionString),
                 //options => options.UseMicrosoftJson() );
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);

            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
            

            // modelBuilder.Entity<Bank>(entity =>
            // {
            //     entity.ToTable("banks");              
            //     //entity.HasIndex(e => e.Catid, "catidIndx");
            //     entity.HasIndex(e => e.Ownerid, "owneridIndx");
            //     entity.HasIndex(e => e.Shopid, "shopidIndx");                
            //  });
        }
}
