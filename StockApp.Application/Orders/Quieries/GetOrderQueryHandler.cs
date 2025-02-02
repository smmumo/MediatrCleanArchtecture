

using MediatR;
using StockApp.Application.Queries;
using StockApp.Domain;

namespace StockApp.Application.Products.Queries
{
    internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<OrderResponse>>
    {
        private readonly IOrderRepository _orderService;
      
        public GetOrderQueryHandler(IOrderRepository orderService){
            _orderService = orderService;           
        }
        public async Task<List<OrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await  _orderService.GetAll();
            List<OrderResponse> orderResponses = [];
            foreach (var item in orders)
            {
                var orderResponse  = new OrderResponse(item.Id.Value,
                    item.ProductId.Value.ToString(),
                    item.CustomerId.Value.ToString(),
                    item.Price.Currency,item.Price.Amount);

                    orderResponses.Add(orderResponse);
            }
           
           return orderResponses;
        }
    }
}