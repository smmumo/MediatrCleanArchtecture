

using System.Reflection;

using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Application.Behaviours;
using StockApp.Application.Exceptions;
using StockApp.Application.Validation;

namespace StockApp.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services) { 
       
        //services.AddMediatR(typeof(DependencyInjection).Assembly) ;

        services.AddMediatR(cfg=>{
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

             //cfg.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));

             cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        } );

        // services.AddFluentValidationAutoValidation()
        //     .AddFluentValidationClientsideAdapters()
        //     .AddValidatorsFromAssemblyContaining<ProductValidator>();

         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddValidatorsFromAssemblyContaining<ProductValidator>();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        //services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

        // services.AddScoped<IPipelineBehavior<RegisterCommand,ErrorOr<AuthenticationResult>>
        //  ,ValidateRegisterCommandBehavior>();

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
