using CasaDiana.Models;

namespace CasaDiana.Dto
{

    public class UserDto 
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Rol Rol { get; set; } = Rol.User;


    }
}
