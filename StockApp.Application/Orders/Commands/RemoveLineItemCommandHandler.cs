using FluentResults;
using MediatR;
using StockApp.Domain;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;


namespace StockApp.Application.Command
{
    
    internal class RemoveLineItemCommandHandler : IRequestHandler<RemoveLineItemCommand,Result>
    {
        private readonly IOrderRepository _orderService;
        private readonly IUnitOfWork _unitOfWork;
      
        public RemoveLineItemCommandHandler(IOrderRepository orderService,IUnitOfWork unitOfWork){
            _orderService = orderService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService
                     .GetByIdWithLineItemAsync(request.OrderId,request.LineItemId);

            if(order == null){
                return Result.Fail("order can not be null");
            }

            order.RemoveLineItems(request.LineItemId);

           int resp = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(resp > 0){
                return Result.Ok();
            }else{
                return Result.Fail("Error Removing Item");
            }
        }
    }
}