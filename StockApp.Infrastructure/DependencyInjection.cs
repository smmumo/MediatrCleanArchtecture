
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options ; //.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Domain;
using StockApp.Infrastracture.Persistence.Repository;
using StockApp.Domain.DbContext;
using StockApp.Infrastracture.Persistence;
using StockApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;

namespace StockApp.Infrastructure;

public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration) { 
       
        services.AddPersistence();
               // .AddAuth(configuration)

        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MoneyTransferHandler).Assembly));
        //services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

       // services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        
        return services;
    }

     public static IServiceCollection AddPersistence(this IServiceCollection services) {

       // var connectionString = "server=127.0.0.1;user=learn_dev;password=7Ja5q0JLM6me-+*61;database=learndotnet";

        // var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));
      
         services.AddDbContext<ApplicationDbContext>();
            
          services.AddScoped<IOrderRepository ,OrderRepository>() ; 
          services.AddScoped<IUnitOfWork ,UnitOfWorkRepository>()   ; 
          services.AddScoped<IProductRepository ,ProductRepository>()   ; 
           services.AddScoped<ICustomerRepository ,CustomerRepository>()   ; 

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services,ConfigurationManager configuration) {
        return services;
    }
}