using AHRestAPI.Mappers;
using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AHRestAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RoomsC : ControllerBase
    {
        
        [HttpGet]
        [Route("/rooms/allfreerooms")]
        public ActionResult<List<RoomsDTO>> GetAllFreeRooms()
        {
            List<Room> RoomList = DataBaseConnection.Context.Rooms.ToList().Where(x => x.RoomStatusid == 1).ToList();
            if (RoomList == null)
            {
                return BadRequest();
            }
            else
            {
                List<RoomsDTO> DTOList = RoomsMapper.ConvertToRoomsDTO(RoomList);
                return DTOList;
            }
        }
        [HttpGet]
        [Route("/rooms/allrooms")]
        public ActionResult<List<RoomsDTO>> GetAllRooms()
        {
            List<Room> RoomList = DataBaseConnection.Context.Rooms.ToList();
            if (RoomList == null)
            {
                return BadRequest();
            }
            else
            {
                List<RoomsDTO> DTOList = RoomsMapper.ConvertToRoomsDTO(RoomList);
                return DTOList;
            }
        }
        [HttpGet]
        [Route("/rooms/checkAvailible")]
        public ActionResult<List<RoomsDTO>> GetNonBookedRooms(DateOnly admDate, DateOnly issueDate)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            List<Room> RoomList = DataBaseConnection.Context.Rooms.ToList().Where(x => x.RoomStatusid != 1).ToList();
            List<Room> freeRooms = DataBaseConnection.Context.Rooms.ToList();
            if (RoomList != null)
            {

                foreach (Room room in RoomList)
                {
                    List<Order> orders = DataBaseConnection.Context.Orders.ToList().Where(x => x.RoomId == room.RoomId).ToList();
                    if (orders != null)
                    {
                        foreach (Order order in orders)
                        {
                            if (admDate >= order.AdmissionDate && issueDate <= order.IssueDate ||
                                order.AdmissionDate >= admDate && order.IssueDate <= issueDate ||
                                admDate <= order.IssueDate && issueDate >= order.AdmissionDate ||
                                order.AdmissionDate <= issueDate && order.IssueDate >= admDate)
                            {
                                freeRooms.Add(room);
                            }
                            List<RoomsDTO> rooms = RoomsMapper.ConvertToRoomsDTO(freeRooms);
                            return Ok(rooms);
                        }
                    }
                } 
            }
            else
            {
                return BadRequest("Orders not getted!");
            }
            return Ok(JsonSerializer.Serialize(freeRooms, options));
        }
    }
}
