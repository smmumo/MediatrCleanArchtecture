using MediatR;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Create
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork){
            _productRepository = productRepository;
             _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
          
            if (product == null){
                throw new ProductNotFoundException(request.ProductId);
            }

            product.Update(request.Name,
                    new Money(request.Currency,request.Amount),
                     Sku.Create(request.Sku)!);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
           
        }
    }

    
}