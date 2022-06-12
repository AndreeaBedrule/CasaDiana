using CasaDiana.Dto;

namespace CasaDiana.Service.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationDto> AddReservation(ReservationDto reservationDto);
        public Task<List<ReservationDto>> GetAllReservations();
        public Task<int> Delete(int id);
        public Task<List<ReservationDto>> GetAllAvaibleReservations();
        public Task<List<ReservationDto>> GetAllUsersReservations(int id);
        public Task<ReservationDto> UpdateReservation(ReservationDto reservationDto);

    }
}
