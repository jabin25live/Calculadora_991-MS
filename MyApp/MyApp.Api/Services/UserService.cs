using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Api.Models;

namespace MyApp.Api.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();
        private readonly object _lock = new();
        private int _nextId = 1;

        public Task<IEnumerable<User>> GetAllAsync()
        {
            lock (_lock)
            {
                // Devolvemos una copia de la lista para evitar problemas de modificación concurrente
                return Task.FromResult<IEnumerable<User>>(_users.ToList());
            }
        }

        public Task<User?> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                return Task.FromResult(user);
            }
        }

        public Task<User> CreateAsync(User user)
        {
            lock (_lock)
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                user.Id = _nextId++;
                _users.Add(user);
                return Task.FromResult(user);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            lock (_lock)
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    _users.Remove(user);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
        }
    }
}
