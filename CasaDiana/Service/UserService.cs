using CasaDiana.Dto;
using CasaDiana.Dto.Mapper;
using CasaDiana.Models;
using CasaDiana.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CasaDiana.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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
        public string Login(AuthentiactionCredentials credentials)
        {
            var user = _userRepository.FindByEmail(credentials.Email);

            if (user == null)
            {
                throw new Exception("Userul nu exista");
            }

            if (user.Password != PasswordHash(credentials.Password))
            {
                throw new Exception("Wrong username or password.");
            }

            string token = CreateToken(user);

            return token;

        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("role", user.Rol.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



        public async Task<UserDto> GetOne(int id)
        {
            return UserMapper.userToUserDto(
                await _userRepository.GetOne(id));

        }
    

        

    }
}
