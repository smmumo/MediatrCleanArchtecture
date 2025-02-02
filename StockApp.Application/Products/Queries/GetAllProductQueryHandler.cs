

using MediatR;
using StockApp.Domain.DbContext;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Queries
{
    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;      
        public GetAllProductQueryHandler(IProductRepository productRepository){
            _productRepository = productRepository;
        }
        public async Task<List<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            List<ProductResponse> productResponses = [];
            foreach (var product in products)
            {
               var productItem =  new ProductResponse(product.Id.Value,product.Name,product.Sku.Value,product.Price.Currency,product.Price.Amount);
                productResponses.Add(productItem);  
            }
           return productResponses;
        }
    }
}