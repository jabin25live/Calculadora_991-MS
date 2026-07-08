using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyApp.Api.Controllers;
using MyApp.Api.Models;
using MyApp.Api.Services;
using Xunit;

namespace MyApp.Api.Tests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _controller = new UsersController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetAsync_ReturnsOkResult_WithThreeUsers_AndInvokesGetAllAsyncOnce()
        {
            // Arrange (Práctica 1)
            var users = new List<User>
            {
                new() { Id = 1, Name = "Alice", Email = "alice@test.com" },
                new() { Id = 2, Name = "Bob", Email = "bob@test.com" },
                new() { Id = 3, Name = "John", Email = "john@test.com" }
            };
            _userServiceMock.Setup(service => service.GetAllAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
            Assert.Equal(3, returnedUsers.Count());
            _userServiceMock.Verify(service => service.GetAllAsync(), Times.Once());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WithCorrectUser_WhenUserExists()
        {
            // Arrange (Práctica 2)
            var expectedUser = new User { Id = 1, Name = "Alice", Email = "alice@test.com" };
            _userServiceMock.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await _controller.GetByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(1, returnedUser.Id);
            _userServiceMock.Verify(service => service.GetByIdAsync(1), Times.Once());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFoundResult_WhenUserDoesNotExist()
        {
            // Arrange (Práctica 3)
            _userServiceMock.Setup(service => service.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _controller.GetByIdAsync(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _userServiceMock.Verify(service => service.GetByIdAsync(99), Times.Once());
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedAtActionResult_AndInvokesCreateAsyncOnce()
        {
            // Arrange (Práctica 4)
            var newUser = new User { Name = "John Doe", Email = "john@test.com" };
            var createdUser = new User { Id = 4, Name = "John Doe", Email = "john@test.com" };
            _userServiceMock.Setup(service => service.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            // Act
            var result = await _controller.CreateAsync(newUser);

            // Assert
            var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetByIdAsync), createdAtResult.ActionName);
            var returnedUser = Assert.IsType<User>(createdAtResult.Value);
            Assert.Equal(4, returnedUser.Id);
            _userServiceMock.Verify(service => service.CreateAsync(newUser), Times.Once());
        }

        [Fact]
        public async Task CreateAsync_SendsCorrectParameters()
        {
            // Arrange (Práctica 5)
            var userToSend = new User { Name = "John Test", Email = "john@test.com" };
            var returnedUser = new User { Id = 5, Name = "John Test", Email = "john@test.com" };
            _userServiceMock.Setup(service => service.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(returnedUser);

            // Act
            await _controller.CreateAsync(userToSend);

            // Assert
            _userServiceMock.Verify(service => service.CreateAsync(It.Is<User>(u => u.Email == "john@test.com")), Times.Once());
        }

        [Fact]
        public async Task GetAllAsync_CallbackIncrementsCounter()
        {
            // Arrange (Práctica 6)
            int callCount = 0;
            _userServiceMock.Setup(service => service.GetAllAsync())
                .Callback(() => callCount++)
                .ReturnsAsync([]);

            // Act
            await _controller.GetAsync();

            // Assert
            Assert.Equal(1, callCount);
        }

        [Fact]
        public async Task DeleteAsync_UserExists_ReturnsNoContentResult_AndInvokesDeleteAsync()
        {
            // Arrange (Práctica 7: Caso 1)
            var existingUser = new User { Id = 1, Name = "Alice", Email = "alice@test.com" };
            _userServiceMock.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(existingUser);
            _userServiceMock.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _userServiceMock.Verify(service => service.GetByIdAsync(1), Times.Once());
            _userServiceMock.Verify(service => service.DeleteAsync(1), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_UserDoesNotExist_ReturnsNotFoundResult_AndDoesNotInvokeDeleteAsync()
        {
            // Arrange (Práctica 7: Caso 2)
            _userServiceMock.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _userServiceMock.Verify(service => service.GetByIdAsync(1), Times.Once());
            _userServiceMock.Verify(service => service.DeleteAsync(It.IsAny<int>()), Times.Never());
        }

        [Fact]
        public async Task DesafioFinal_ValidatesFlow_InvokesEachMethodExactlyOnce()
        {
            // Arrange (Desafío Final)
            var user = new User { Id = 1, Name = "John", Email = "john@test.com" };
            _userServiceMock.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(user);
            _userServiceMock.Setup(service => service.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(user);
            _userServiceMock.Setup(service => service.GetAllAsync())
                .ReturnsAsync([user]);

            // Act
            await _controller.GetByIdAsync(1);
            await _controller.CreateAsync(user);
            await _controller.GetAsync();

            // Assert
            _userServiceMock.Verify(service => service.GetByIdAsync(1), Times.Once());
            _userServiceMock.Verify(service => service.CreateAsync(user), Times.Once());
            _userServiceMock.Verify(service => service.GetAllAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateAsync_ReturnsBadRequestResult_WhenUserIsNull()
        {
            // Act
            var result = await _controller.CreateAsync(null!);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
