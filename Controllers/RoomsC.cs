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
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("/rooms/checkAvailible")]
        public ActionResult<List<RoomsDTO>> GetNonBookedRooms(DateOnly admDate, DateOnly issueDate)
        {
            List<Room> RoomList = DataBaseConnection.Context.Rooms.Include(room => room.Orders).ToList();
            List<RoomsDTO> DTOList;

            if (admDate != DateOnly.MinValue && issueDate != DateOnly.MinValue)
            {
                RoomList = RoomList.Where(x => !x.Orders.Any(y => y.AdmissionDate <= issueDate && y.IssueDate >= admDate)).ToList();
            }

            DTOList = RoomsMapper.ConvertToRoomsDTO(RoomList);
            return DTOList;
        }
    }
}