using CasaDiana.Models;


namespace CasaDiana.Dto.Mapper
{
    public class UserMapper 
    {
        public static UserDto userToUserDto(User user)
        {

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };          
               
           
        
        }
        public static User userDtoToUser(UserDto userDto)
        {

            return new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
            };



        }

    }
}
