using CasaDiana.Models;

namespace CasaDiana.Dto.Mapper
{
    public class RoomMapper
    {
        public static RoomDto roomToRoomDto(Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Floor = room.Floor,
                Number = room.Number,
                NumberOfPersons = room.NumberOfPersons,
                Price = room.Price,
                Smoking = room.Smoking,
                HairDryer = room.HairDryer,
                Bath = room.Bath,
            };
        }

        public static Room roomDtoToRoom(RoomDto roomDto)
        {
            return new Room
            {
                Id = roomDto.Id,
                Floor = roomDto.Floor,
                Number = roomDto.Number,
                NumberOfPersons = roomDto.NumberOfPersons,
                Price = roomDto.Price,
                
                Smoking = roomDto.Smoking,
                HairDryer = roomDto.HairDryer,
                Bath = roomDto.Bath,
            };
        }

        public static List<RoomDto> roomsToRoomsDto(List<Room> rooms)
        {
            var roomsDto = new List<RoomDto>();
            foreach(Room room in rooms)
            {
                roomsDto.Add(roomToRoomDto(room));
            }
            return roomsDto;
        }
        /*public static List<Room> roomsDtoToRooms(List<RoomDto> rooms)
        {
            var rooms1 = new List<Room>();
            foreach(RoomDto roomDto in rooms)
            {
                rooms1.Add(roomDtoToRoom(roomDto));
            }
            return rooms1;

            
        }*/
    }
}
