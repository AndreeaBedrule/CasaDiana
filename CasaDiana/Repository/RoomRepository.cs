using CasaDiana.Models;
using CasaDiana.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;
        private readonly IReservationRepository _reservationRepository;
        public RoomRepository(DataContext context, IReservationRepository reservationRepository)
        {
            _context = context;
            _reservationRepository = reservationRepository;
        }

        public async Task<Room> AddAsync(Room room)
        {
            await _context.Room.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;

        }

        public async Task<bool> RoomExists(int number)
        {
            if (await _context.Room.AnyAsync(x => x.Number == number))
                return true;

            return false;
        }

        public async Task<List<Room>> GetAll() 
        {
            return await _context.Room.ToListAsync();

        }

        public async Task<Room> Delete(int id)
        {
            var room = new Room { Id = id };

            _context.Room.Attach(room);
            _context.Remove(room);
            await _context.SaveChangesAsync();

            return room;
            
        }
        public async Task<Room> UpdateRoom(Room room)
        {
            _context.Room.Attach(room);
            _context.Update(room);
            await _context.SaveChangesAsync();

            return room;


        }

        public async Task<Room> GetOne(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
                throw new ArgumentException("Room not found");
            return room;
        }

        
        


    }
}
