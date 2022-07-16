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
            if (null == room)
            {
                throw new Exception("Camera nu exista.");
            }

            var user = await _userRepository.GetOne(reservationDto.UserId);
            if (null == user)
            {
                throw new Exception("Utilizatorul nu exista.");
            }

            reservationDto.TotalPrice = (int)(reservationDto.CheckOut - reservationDto.CheckIn).TotalDays * room.Price;
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
        public async Task<int> Delete(int id)
        {
            await _reservationRepository.Delete(id);
            return id;
        }

        public async Task<List<ReservationDto>>GetAllAvaibleReservations()
        {
            return ReservationMapper.reservationsToReservationsDto(
                await _reservationRepository.GetAllAvailableReservations());
        }

        public async Task<List<ReservationDto>>GetAllUsersReservations(int id)
        {
            return ReservationMapper.reservationsToReservationsDto(
                await _reservationRepository.GetAllUsersReservations(id));
        }

        public async Task<ReservationDto> UpdateReservation(ReservationDto reservationDto)
        {
            var user = await _userRepository.GetOne(reservationDto.UserId);
            if (null == user)
            {
                throw new Exception("User does not exist!");
            }

            var room = await _roomRepository.GetOne(reservationDto.RoomId);
            if (null == room)
            {
                throw new Exception("Room does not exist!");
            }

            var reservationToUpdate = ReservationMapper.reservationDtoToReservation(reservationDto);
           
            reservationToUpdate.User = user;
            reservationToUpdate.Room = room;
            reservationToUpdate.TotalPrice = (int)(reservationDto.CheckOut - reservationDto.CheckIn).TotalDays * room.Price;

            return ReservationMapper.reservationToReservationDto(
                await _reservationRepository.UpdateReservation(reservationToUpdate)
                );
            


        }


    }
}
