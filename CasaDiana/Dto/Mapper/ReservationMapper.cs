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
                CheckIn = reservation.Check_in,
                CheckOut = reservation.Check_out,
                UserId = reservation.User.Id,
                RoomId = reservation.Room.Id,
                Canceled = reservation.Canceled,
                Room = reservation.Room != null ? RoomMapper.roomToRoomDto(reservation.Room) : null,
            };
        }

        public static Reservation reservationDtoToReservation(ReservationDto reservation)
        {
            return new Reservation
            {
                Id = reservation.Id,
                Check_out = reservation.CheckOut,
                Check_in = reservation.CheckIn,
                Canceled = reservation.Canceled,
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
