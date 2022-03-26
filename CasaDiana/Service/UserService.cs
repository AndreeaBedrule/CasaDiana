using CasaDiana.Dto;
using CasaDiana.Dto.Mapper;
using CasaDiana.Models;
using CasaDiana.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CasaDiana.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<UserDto> Register(UserDto userDto)
        {
            if (await _userRepository.UserExists(userDto.Email))
            {
                throw new Exception("Utilizatorul exista deja");
            }
            userDto.Password = PasswordHash(userDto.Password);
            
            return UserMapper.userToUserDto(
                await _userRepository.AddAsync(
                    UserMapper.userDtoToUser(userDto)
                    )
                );
        }
         private string PasswordHash(string password)
         {
             var crypt = new SHA256Managed();
             string hash = String.Empty;
             byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
             foreach (byte theByte in crypto)
             {
                 hash += theByte.ToString("x2");
             }
             return hash;
         }
        public UserDto Login(UserDto userDto)
        {
            var user = _userRepository.FindByEmail(userDto.Email);

            if (user == null)
            {
                throw new Exception("Userul nu exista");
            }

            if (user.Password != PasswordHash(userDto.Password))
            {
                throw new Exception("Wrong username or password.");
            }

            return UserMapper.userToUserDto(user);

        }
    

        

    }
}
