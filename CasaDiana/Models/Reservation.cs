namespace CasaDiana.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public bool Canceled { get; set; }
        public int TotalPrice { get; set; }
    }
}
