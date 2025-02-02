
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApp.Api.Controllers;
using StockApp.Application.Products.Create;
using StockApp.Application.Products.Delete;
using StockApp.Application.Products.Queries;
using StockApp.Domain.Products;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase 
{
    private readonly ISender _sender;
    public ProductController(ISender sender){
        _sender = sender;
    }

    [HttpGet("fetchproduct")]  
    public async Task<IActionResult> GetAll(){
        GetAllProductQuery command = new();
        var orders =  await   _sender.Send(command);
        //await Task.CompletedTask;
        return Ok(orders);
    }


    [HttpPost("createproduct")]
    //[Route("createproduct")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command){
       
        // if(!ModelState.IsValid){
        //     var message = ModelState.SelectMany(modelState => modelState.Value.Errors)
        //     .Select(err => err.ErrorMessage).ToList();

        //     return BadRequest(message);
        // }

        await   _sender.Send(command);
        return Ok();
    }

    [HttpDelete("delete/{id:guid}")]
    //[Route("/{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid Id){
        try
        {
            await   _sender.Send(new DeleteProductCommand(new StockApp.Domain.Entities.ProductId(Id)));
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {            
            return NotFound(e.Message);
        }       
    }

    [HttpPut("update/{id:guid}")]
    // [Route("/{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] UpdateProductRequest request){
        try
        {
            var command = new UpdateProductCommand(
                new StockApp.Domain.Entities.ProductId(Id),request.Name,
                request.Sku,
                request.Currency,
                request.Amount
            );
            await   _sender.Send(command);
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {            
            return NotFound(e.Message);
        }       
    }

    

}