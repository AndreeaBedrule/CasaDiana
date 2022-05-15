using CasaDiana.Models;

namespace CasaDiana.Dto.Mapper
{
    public class ReservationMapper
    {
        public static ReservationDto reservationToReservationDto(Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                Check_in = reservation.Check_in,
                Check_out = reservation.Check_out,
                UserId = reservation.User.Id,
                RoomId = reservation.Room.Id,

            };
        }

        public static Reservation reservationDtoToReservation(ReservationDto reservation)
        {
            return new Reservation
            {
                Id = reservation.Id,
                Check_out = reservation.Check_out,
                Check_in = reservation.Check_in,

            };
        }

        public static List<ReservationDto> reservationsToReservationsDto(List<Reservation> reservations)
        {
            var reservationsDto = new List<ReservationDto>();
            foreach (Reservation reservation in reservations)
            {
                reservationsDto.Add(reservationToReservationDto(reservation));
            }
            return reservationsDto;
        }
    }
}
