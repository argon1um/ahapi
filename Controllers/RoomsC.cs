using AHRestAPI.Mappers;
using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
