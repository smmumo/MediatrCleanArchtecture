

// using System.Text.Json;
// using MediatR;
// using Microsoft.Extensions.Logging;

// namespace StockApp.Application.Behaviours;
// public class RequestResponseLoggingBehavior<TRequest, TResponse>(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
//     : IPipelineBehavior<TRequest, TResponse>
//     where TRequest : class
// {
//     public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
//             CancellationToken cancellationToken)
//     {
//        var correlationId = Guid.NewGuid();

//         // Request Logging
//         // Serialize the request
//         var requestJson = JsonSerializer.Serialize(request);

//          // Log the serialized request
//         logger.LogInformation("Handling request {CorrelationID}: {Request}", correlationId, requestJson);

//          // Response logging
//         var response = await next();

//         // Serialize the response
//         var responseJson = JsonSerializer.Serialize(response);
//         // Log the serialized response
//         logger.LogInformation("Response for {Correlation}: {Response}", correlationId, responseJson);

//         // Return response
//         return response;
//     }
// }