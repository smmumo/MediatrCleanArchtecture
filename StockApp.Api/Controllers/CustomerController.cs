
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Controllers;
using StockApp.Application.CreateCustomer;
using StockApp.Application.CustomerQueries;


[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase 
{
    private readonly ISender _sender;
    public CustomerController(ISender sender){
        _sender = sender;
    }

    [HttpGet("fetchcustomers")]  
    public async Task<IActionResult> GetAll(){
        GetAllCustomerQuery command = new();
        var orders =  await   _sender.Send(command);
        //await Task.CompletedTask;
        return Ok(orders);
    }

    [HttpPost("createcustomer")]    
    public async Task<IActionResult> CreateProduct(CreateCustomerCommand command){       
        // if(!ModelState.IsValid){
        //     var message = ModelState.SelectMany(modelState => modelState.Value.Errors)
        //     .Select(err => err.ErrorMessage).ToList();

        //     return BadRequest(message);
        // }
        await   _sender.Send(command);
        return Ok();
    }
}