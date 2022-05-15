using CasaDiana.Models;

namespace CasaDiana.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public  Task<Room> AddAsync(Room room);
        public  Task<bool> RoomExists(int number);
        public Task<List<Room>> GetAll();
        public Task<Room> Delete(int id);
        public Task<Room> UpdateRoom(Room room);
        public Task<Room> GetOne(int id);
    }
}
