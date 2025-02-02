
// using Xunit;
// using Moq;
// using MyApp.Application.Services;
// using MyApp.Application.Core.Repositories;
// using MyApp.Application.Models.DTOs;
// using MyApp.Domain.Entities.MysqlModels;

// namespace MyApp.Application.Test.Services;
// public class UserServiceTest
// {
//     private  Mock<IUnitOfWork> _unitOfWorkMock  = new Mock<IUnitOfWork>();
//     private readonly UserService _userService;
//     public UserServiceTest()
//     {
//         _userService = new UserService(_unitOfWorkMock.Object);
//     }

//     public  void Given_ValidData_Then_ReturnsResult()
//     {
//         //Arrage
//         User user = new()
//         {
//             Id = 1,
//             Userid = "Simon",
//             Username = "",
//             Email = "simon@gmail",
//             Phone = "09546554"
//         };
//         User user2 = new()
//         {
//             Id = 2,
//             Userid = "Simon",
//             Username = "",
//             Email = "simon@gmail",
//             Phone = "09546554"
//         };        
//         List<User> userList = new()
//         {
//             user,user2
//         };
       
//         _unitOfWorkMock.Setup(x => x.Repository<User>().FindAll().ToList()).Returns(userList);

//         //Act 
//         var result =  _userService.GetShopOwners();

//         //Assert
//         Assert.NotEmpty(result);
//         Assert.Equal(userList.Count, result.Count);
//     }

//     // [Fact]
//     // public async void Given_WithValidData_When_CreateUser_Then_SuccessfullyCreateUser()
//     // { 
//     //     //Arrage
//     //     //Act
//     //     //Assert
//     // }

//     // public async void Given_ValidData_When_ValidateUser_Then_ReturnsResult()
//     // {

//     // }
// }