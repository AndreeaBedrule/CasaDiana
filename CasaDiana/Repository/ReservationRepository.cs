using CasaDiana.Data;
using CasaDiana.Models;
using CasaDiana.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CasaDiana.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _context.Reservation
                .Include(x => x.User)
                .Include(x => x.Room)
                .ToListAsync();
        }


    }
            
    
}
