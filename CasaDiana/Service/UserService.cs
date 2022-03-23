using CasaDiana.Models;
using CasaDiana.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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

        public async Task<User> Register(User user)
        {
            if (await _userRepository.UserExists(user.Email))
            {
                throw new Exception("Utilizatorul exista deja");
            }
            user.Password = PasswordHash(user.Password);
            
            return await _userRepository.AddAsync(user);
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


    }
}
