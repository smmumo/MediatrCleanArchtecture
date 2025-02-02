

using FluentResults;
using MediatR;
using StockApp.Domain.DbContext;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Queries
{
    
    internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly IProductRepository _productRepository;      
        public GetProductQueryHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
           var product = await _productRepository.GetByIdAsync(request.ProductId);

           return new ProductResponse(product.Id.Value,product.Name,product.Sku.Value,product.Price.Currency,product.Price.Amount);
        }
    }
}