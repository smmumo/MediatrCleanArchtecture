
using FluentResults;
using MediatR;

using StockApp.Application.CreateCustomer;
using StockApp.Domain;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Create
{
    //https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
         private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork
        ){
            _customerRepository = customerRepository ;
             _unitOfWork = unitOfWork ;
        }

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer =  Customer.Create(request.Email,request.Name);

            _customerRepository.Add(customer);  

            await _unitOfWork.SaveChangesAsync(cancellationToken);
           // var customer = _customerRepository.Get()
        }
    }
}