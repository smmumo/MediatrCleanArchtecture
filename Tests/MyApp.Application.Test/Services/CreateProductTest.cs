using FluentResults;
using MediatR;
using Moq;
using StockApp.Application.Products.Create;
using StockApp.Domain.DbContext;
using StockApp.Domain.Entities;
using StockApp.Domain.Products;

namespace MyApp.Application.Tests;
public class CreateProductCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IProductRepository> _productRepository ;
    private Mock<IPublisher> _publisher;

    public CreateProductCommandHandlerTest(){
         _unitOfWork = new();
         _productRepository = new();
         _publisher = new();
    }
    
    [Fact]
    public async Task Handler_Should_Should_Return_Failure_WhenNameIsEmpty(){

        //arrage , prepare param data
        var command = new CreateProductCommand("","KSH",300);       

        _productRepository.Setup(p => p.Add(It.IsAny<Product>()));

        var handler = new CreateProductCommandHandler(_productRepository.Object,_unitOfWork.Object,_publisher.Object);

        //act, execute
         await handler.Handle(command,default);       

         //Assert
        _unitOfWork.Verify(
                x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),Times.Never());

    }
}