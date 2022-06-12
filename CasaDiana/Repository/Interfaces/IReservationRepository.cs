using CasaDiana.Models;

namespace CasaDiana.Repository.Interfaces
{
    public interface IReservationRepository
    {
        public Task<Reservation> AddAsync(Reservation reservation);
        public Task<List<Reservation>> GetAll();
        public Task<Reservation> Delete(int id);
        public Task<List<Reservation>> GetAllAvailableReservations();
        public Task<List<Reservation>> GetAllUsersReservations(int id);
        public Task<Reservation> UpdateReservation(Reservation reservation);
    }
}
