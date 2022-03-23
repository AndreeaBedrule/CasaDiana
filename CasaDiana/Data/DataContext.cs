using CasaDiana.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Data
{
    public class DataContext : DbContext
    {
        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
