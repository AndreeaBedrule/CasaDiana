using CasaDiana.Dto;
using CasaDiana.Models;
using CasaDiana.Repository;

namespace CasaDiana.Service
{
    public interface IUserService
    {
        public Task<UserDto> Register(UserDto userDto);
        public UserDto Login(UserDto userDto);
    }
}
