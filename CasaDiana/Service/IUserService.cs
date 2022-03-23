using CasaDiana.Models;
using CasaDiana.Repository;

namespace CasaDiana.Service
{
    public interface IUserService
    {
        public Task<User> Register(User user);
    }
}
