using CasaDiana.Models;

namespace CasaDiana.Dto
{
    public class ReservationDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int RoomId { get; set; } 
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
    }
}
