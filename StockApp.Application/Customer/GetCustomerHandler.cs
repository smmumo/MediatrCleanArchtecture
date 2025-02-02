

using MediatR;
using StockApp.Application.CustomerQueries;
using StockApp.Domain;
using StockApp.Domain.DbContext;
using StockApp.Domain.Products;

namespace StockApp.Application.Products.Queries
{
    internal sealed class GetCustomersQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;      
        public GetCustomersQueryHandler(ICustomerRepository customerRepository){
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll();
            List<CustomerResponse> customersResponses = [];
            foreach (var item in customers)
            {
               var customerlist =  new CustomerResponse(item.Id.Value,item.Name,item.Email);
                customersResponses.Add(customerlist);  
            }
           return customersResponses;
        }

      
    }
}