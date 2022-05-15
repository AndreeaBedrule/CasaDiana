using CasaDiana.Dto;
using CasaDiana.Dto.Mapper;
using CasaDiana.Models;
using CasaDiana.Repository.Interfaces;

namespace CasaDiana.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public RoomService(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<RoomDto> AddRoom(RoomDto roomDto)
        {
            return RoomMapper.roomToRoomDto(await _roomRepository.AddAsync(
                RoomMapper.roomDtoToRoom(roomDto)
                )
            );
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            return RoomMapper.roomsToRoomsDto(
                await _roomRepository.GetAll());   
        }

        public async Task<RoomDto> GetOne(int id)
        {
            return RoomMapper.roomToRoomDto(
                await _roomRepository.GetOne(id));
        }
         public async Task<RoomDto> Delete(int id)
        {
             return RoomMapper.roomToRoomDto(await _roomRepository.Delete(id));
                 
        }

        public async Task<RoomDto> Update(RoomDto roomDto)
        {
            return RoomMapper.roomToRoomDto(await _roomRepository.UpdateRoom(
                RoomMapper.roomDtoToRoom(roomDto)));
        }

        public async Task<List<Room>> GetAllAvailableRooms(DateTime check_in, DateTime check_out)
        {
            var rooms = await _roomRepository.GetAll() ;
            var reservations = await _reservationRepository.GetAll() ;
            var availableRooms =  new List<Room>();
            bool ok;
            foreach (var room in rooms)
            {
                ok = true;
                foreach (var reservation in reservations)
                {
                    if ((
                       (check_in.Date < reservation.Check_in && check_out.Date > reservation.Check_out) ||
                       (check_in.Date > reservation.Check_in && check_out.Date > reservation.Check_out && check_in.Date < reservation.Check_out) ||
                       (check_in.Date < reservation.Check_in && check_out.Date < reservation.Check_out && reservation.Check_in < check_out.Date) ||
                       (check_in.Date > reservation.Check_in && check_out.Date < reservation.Check_out)) &&
                                 room.Id == reservation.Room.Id)
                    {
                        ok = false;
                    }

                }
                if (ok)
                    availableRooms.Add(room);
            }

            return availableRooms;
        }
    }
}
