using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Api.Models;
using MyApp.Api.Services;
using Xunit;

namespace MyApp.Api.Tests
{
    public class UserServiceTests
    {
        private readonly UserService _service;

        public UserServiceTests()
        {
            _service = new UserService();
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmptyInitially()
        {
            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task CreateAsync_AddsUser_AndAssignsId()
        {
            // Arrange
            var newUser = new User { Name = "Alice", Email = "alice@test.com" };

            // Act
            var created = await _service.CreateAsync(newUser);
            var allUsers = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(created.Id);
            Assert.Equal("Alice", created.Name);
            Assert.Contains(allUsers, u => u.Id == created.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingUser_ReturnsUser()
        {
            // Arrange
            var user = new User { Name = "Bob", Email = "bob@test.com" };
            var created = await _service.CreateAsync(user);

            // Act
            var retrieved = await _service.GetByIdAsync(created.Id!.Value);

            // Assert
            Assert.NotNull(retrieved);
            Assert.Equal(created.Id, retrieved.Id);
            Assert.Equal("Bob", retrieved.Name);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingUser_ReturnsNull()
        {
            // Act
            var retrieved = await _service.GetByIdAsync(999);

            // Assert
            Assert.Null(retrieved);
        }

        [Fact]
        public async Task DeleteAsync_ExistingUser_RemovesUser_AndReturnsTrue()
        {
            // Arrange
            var user = new User { Name = "Charlie", Email = "charlie@test.com" };
            var created = await _service.CreateAsync(user);

            // Act
            var deleted = await _service.DeleteAsync(created.Id!.Value);
            var allUsers = await _service.GetAllAsync();

            // Assert
            Assert.True(deleted);
            Assert.DoesNotContain(allUsers, u => u.Id == created.Id);
        }

        [Fact]
        public async Task DeleteAsync_NonExistingUser_ReturnsFalse()
        {
            // Act
            var deleted = await _service.DeleteAsync(999);

            // Assert
            Assert.False(deleted);
        }

        [Fact]
        public Task CreateAsync_NullUser_ThrowsArgumentNullException()
        {
            // Act & Assert
            return Assert.ThrowsAsync<System.ArgumentNullException>(() => _service.CreateAsync(null!));
        }
    }
}
