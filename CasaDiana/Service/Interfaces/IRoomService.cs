using CasaDiana.Dto;
using CasaDiana.Models;

namespace CasaDiana.Repository.Interfaces
{
    public interface IRoomService
    {
        public Task<RoomDto> AddRoom(RoomDto roomDto);
        public Task<List<RoomDto>> GetAllRooms();
        public Task<RoomDto> Delete(int id);
        public Task<RoomDto> GetOne(int id);
        public Task<RoomDto> Update(RoomDto roomDto);
        public Task<List<Room>> GetAllAvailableRooms(DateTime check_in, DateTime check_out);
    }
}
