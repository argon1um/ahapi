using AHRestAPI.Models;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AHRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Clients : ControllerBase
    {

        [HttpPost]
        [Route("/clients/signUp")]
        public ActionResult<ClientResponseLogin> ClientRegistration([FromBody] ClientResponseLogin clientregdto)
        {
            if (clientregdto != null)
            {
                List<Client> clients = DataBaseConnection.Context.Clients.ToList();
                clientregdto.ID = DataBaseConnection.Context.Clients.Max(x => x.ClientId)+1;
                DataBaseConnection.Context.Clients.Add(Mappers.ClientRegistartionMapper.ClientConverter(clientregdto));
                DataBaseConnection.Context.SaveChanges();
                return Ok();
            }
            else { return BadRequest("Woops!"); }
        }
    }
}