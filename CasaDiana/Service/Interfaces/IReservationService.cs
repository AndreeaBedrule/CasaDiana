using CasaDiana.Dto;

namespace CasaDiana.Service.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationDto> AddReservation(ReservationDto reservationDto);
        public Task<List<ReservationDto>> GetAllReservations();
    }
}
