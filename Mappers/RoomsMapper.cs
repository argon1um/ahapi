using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class RoomsMapper
    {
        public static Room ConvertToRoom(RoomsDTO roomdto)
        {
            Room room = new Room();
            room.RoomId = roomdto.RoomId;
            room.RoomNumber = roomdto.RoomNumber;
            room.RoomDescription = roomdto.RoomDescription;
            room.RoomTypeid = roomdto.RoomTypeid;
            room.RoomImage = roomdto.RoomImage;
            room.RoomStatusid = roomdto.RoomStatusid;
            return room;

        }

        public static RoomsDTO ConvertToRoomDTO(Room room)
        {
            RoomsDTO room1 = new RoomsDTO();
            room1.RoomId = room.RoomId;
            room1.RoomNumber = room.RoomNumber;
            room1.RoomTypeid = room.RoomTypeid;
            room1.RoomDescription = room.RoomDescription;
            room1.RoomImage = room.RoomImage;
            room1.RoomStatusid = room.RoomStatusid;
            return room1;
        }



        public static List<RoomsDTO> ConvertToRoomsDTO(List<Room> rooms)
        {
            List<RoomsDTO> roomlist = new List<RoomsDTO>();
            foreach (Room room in rooms)
            {
                roomlist.Add(new RoomsDTO
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomTypeid = room.RoomTypeid,
                    RoomDescription = room.RoomDescription,
                    RoomImage = room.RoomImage,
                    RoomStatusid = room.RoomStatusid
                });
            }
            return roomlist;
        }
    }
}
