using CasaDiana.Models;

namespace CasaDiana.Dto
{
    public class ReservationDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int RoomId { get; set; }
        public int RoomPrice { get; set; }
        public DateTime CheckIn { get; set; } 
        public DateTime CheckOut { get; set; } 
        public bool Canceled { get; set; }
        public RoomDto? Room { get; set; }
        public UserDto? User { get; set; }
        public int TotalPrice { get; set; }
    }

}
