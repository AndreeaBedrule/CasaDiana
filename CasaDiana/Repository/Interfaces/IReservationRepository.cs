using CasaDiana.Models;

namespace CasaDiana.Repository.Interfaces
{
    public interface IReservationRepository
    {
        public Task<Reservation> AddAsync(Reservation reservation);
        public Task<List<Reservation>> GetAll();
    }
}
