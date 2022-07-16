using CasaDiana.Dto;
using CasaDiana.Models;
using CasaDiana.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.User.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }
        public User? FindByEmail(string email)
        {
            return _context.User
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }
        public async Task<User> GetOne(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                throw new ArgumentException("Room not found");
            return user;
        }

        public async Task<User> Delete(int id)
        {
            var user = new User { Id = id };

            _context.User.Attach(user);
            _context.Remove(user);
            await _context.SaveChangesAsync();

            return user;

        }
    }
}
