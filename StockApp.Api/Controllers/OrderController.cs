using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Controllers;
using StockApp.Application.Command;
using StockApp.Application.Queries;

[ApiController]
[Route("[controller]")]
public class OrderController(ISender sender) : ControllerBase 
{
    private readonly ISender _sender = sender;

    [HttpPost("createorder")]  
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command){
        var response = await   _sender.Send(command);       
        if(response.IsFailed){
            return BadRequest(response.Errors[0]);
        }
        return Ok(response.IsSuccess);
    }

    [HttpGet("fetchorders")]   
    public async Task<IActionResult> GetOrders(){
        GetOrderQuery command = new();
        var orders =  await   _sender.Send(command);
        //await Task.CompletedTask;
        return Ok(orders);
    }

    [HttpGet("fetchordersbyid")]   
    public async Task<IActionResult> GetOrderById(){
        GetOrderQuery command = new();
        var orders =  await   _sender.Send(command);
        //await Task.CompletedTask;
        return Ok(orders);
    }
}