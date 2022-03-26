using CasaDiana.Models;

namespace CasaDiana.Service
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User user);
        public Task<bool> UserExists(string email);
        public User? FindByEmail(string email);
    }
}
