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
        [Route("/clients/log")]
        public ActionResult<ClientRegistrationDTO> ClientAuthentification([FromBody] ClientDTO clientdto)
        {
            Client clreg = DataBaseConnection.Context.Clients.ToList().FirstOrDefault(x => x.ClientLogin == clientdto.Login && x.ClientPassword == clientdto.Password);
            if (clreg == null)
            {
                return BadRequest();
            }
            else
            {
                return Mappers.ClientRegistartionMapper.ClientConverter(clreg);
            }
        }

        [HttpPost]
        [Route("/clients/reg")]
        public ActionResult<ClientRegistrationDTO> ClientRegistration([FromBody] ClientRegistrationDTO clientregdto)
        {
            if (clientregdto != null)
            {
                List<Client> clients = DataBaseConnection.Context.Clients.ToList();
                foreach (Client client in clients)
                {
                    if (client.ClientLogin == clientregdto.ClientLogin)
                    {
                        return Conflict();
                    }
                }
                clientregdto.ID = DataBaseConnection.Context.Clients.Max(x => x.ClientId)+1;
                DataBaseConnection.Context.Clients.Add(Mappers.ClientRegistartionMapper.ClientConverter(clientregdto));
                DataBaseConnection.Context.SaveChanges();
                return Ok();
            }
            else { return BadRequest("Woops!"); }
        }
    }
}