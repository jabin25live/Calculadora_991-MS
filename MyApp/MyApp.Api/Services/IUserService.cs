#pragma warning disable IDE0130 // El espacio de nombres no coincide con la estructura de carpetas

using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Api.Models;

namespace MyApp.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
}
