
using MediatR;
using StockApp.Domain.DbContext;
using StockApp.Domain.Products;


namespace StockApp.Application.Products.Delete
{
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork){
            _productRepository = productRepository;
             _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null){
                throw new ProductNotFoundException(request.ProductId);
            }

            _productRepository.Remove(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}