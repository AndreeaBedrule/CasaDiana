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

        public async Task<Reservation> Delete(int id)
        {
            var reservation = new Reservation { Id = id };

            _context.Reservation.Attach(reservation);
            _context.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;

        }
         
        public void CancelReservation(Reservation reservation)
        {
          reservation.Canceled = true;
            
        }

        public  async Task<List<Reservation>> GetAllAvailableReservations()
        {
   
            var reservations = _context.Reservation.Where(reservation => reservation.Canceled == false).ToList();

            return reservations;
        }

        public async Task <List<Reservation>> GetAllUsersReservations(int id)
        { 
            var reservations = _context.Reservation.Where(
                reservation => reservation.User.Id == id)
                .Include(reservations => reservations.User)
                .Include(reservations => reservations.Room)
                .ToList();
            return reservations; 
            
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _context.Reservation.Attach(reservation);
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }



    }
            
    
}
