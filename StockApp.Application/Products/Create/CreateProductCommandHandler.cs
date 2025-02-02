using FluentResults;
using MediatR;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Create
{
    //https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher ;
        public CreateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork,
        IPublisher publisher){
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.Currency, request.Amount);

             product.Validate();

            _productRepository.Add(product);
   
            int results =  await _unitOfWork.SaveChangesAsync(cancellationToken);

            // if(results > 0){                
            //     foreach (var domainItemEnvent in product.DomainEvents)
            //     {
            //         await _publisher.Publish(domainItemEnvent,cancellationToken);
            //     }
            // }            
           
        }

        // async Task<Result> IRequestHandler<CreateProductCommand, Result>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        // {
        //     var product = Product.Create(request.Name, request.Currency, request.Amount);

        //      product.Validate();

        //     _productRepository.Add(product);

        //     int results =  await _unitOfWork.SaveChangesAsync(cancellationToken);

        //     return Result.Ok(results > 0);
        // }
    }

    
}