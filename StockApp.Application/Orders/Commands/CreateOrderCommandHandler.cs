using FluentResults;
using MediatR;

using StockApp.Domain;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;

namespace StockApp.Application.Command
{

    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Result>
    {
        private readonly IOrderRepository _orderService;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderCommandHandler(IOrderRepository orderService,IUnitOfWork unitOfWork){
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
            var order = Order.Create(
                request.CustomerId,
                request.ProductId,
                request.Price
            );

            if(request.ProductId is null){
                return Result.Fail("Product Id can not be null");
            }

            if(request.CustomerId is null){
                return Result.Fail("Customer Id can not be null");
            }

            var lineitem = LineItems.Create(order.Id, request.ProductId,request.Price);

            order.AddItems(lineitem);

            _orderService.Add(order);

            int resp = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(resp > 0){
                return Result.Ok();
            }else{
                return Result.Fail("Error Creating Order");
            }

            
        }

        
    }
}