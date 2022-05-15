using CasaDiana.Dto;
using CasaDiana.Models;
using CasaDiana.Repository;

namespace CasaDiana.Service
{
    public interface IUserService
    {
        public Task<UserDto> Register(UserDto userDto);
        public string Login(AuthentiactionCredentials credentials);
        public Task<UserDto> GetOne(int id);
    }
}
