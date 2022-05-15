using CasaDiana.Dto;
using CasaDiana.Dto.Mapper;
using CasaDiana.Repository.Interfaces;
using CasaDiana.Service.Interfaces;

namespace CasaDiana.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public ReservationService(IReservationRepository reservationRepository,IUserRepository userRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _roomRepository = roomRepository;  
        }

        public async Task<ReservationDto> AddReservation(ReservationDto reservationDto)
        {
            var room = await _roomRepository.GetOne(reservationDto.RoomId);
            var user = await _userRepository.GetOne(reservationDto.UserId);
            var reservation = ReservationMapper.reservationDtoToReservation(reservationDto);
            reservation.User = user;
            reservation.Room = room;
            return ReservationMapper.reservationToReservationDto(await _reservationRepository.AddAsync(reservation));
               
              
        }

        public async Task<List<ReservationDto>> GetAllReservations()
        {
            return ReservationMapper.reservationsToReservationsDto(
                await _reservationRepository.GetAll());
        }
    }
}
