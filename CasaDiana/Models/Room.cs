using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int NumberOfPersons { get; set; }
        public int Price { get; set; }
        public bool PetFriendly { get; set; }
        public bool Smoking { get; set; }
        public bool HairDryer { get; set; }
        public bool Bath { get; set; }
    }
}
