using AHRestAPI.Mappers;
using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
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
                DataBaseConnection.Context.Clients.Add(ClientRegistartionMapper.ClientConverter(clientregdto));
                DataBaseConnection.Context.SaveChanges();
                return Ok();
            }
            else { return BadRequest("Woops!"); }
        }

        [HttpPost]
        [Route("/clients/auth/")]
        public ActionResult<ClientResponseLogin> ClientAuth([FromBody] UserAuthDTO userAuthDTO)
        {
            string login ="";
            decimal phone = 0;
            List<Worker> workers = DataBaseConnection.Context.Workers.ToList();
            List<Client> clients = DataBaseConnection.Context.Clients.ToList();
            try
            {
                phone = decimal.Parse(userAuthDTO.Phone);
            }
            catch
            {
                login = userAuthDTO.Phone;
            }
            if (workers != null)
            {
                Worker worker = DataBaseConnection.Context.Workers.FirstOrDefault(x => x.WorkerLogin == login  && x.WorkerPassword == userAuthDTO.Password);
                if (worker != null)
                {
                    return Ok(ClientRegistartionMapper.WorkerToDTO(worker));
                }
                else
                {
                    if (clients != null)
                    {
                        Client client = DataBaseConnection.Context.Clients.FirstOrDefault(x => x.ClientPassword == userAuthDTO.Password && x.ClientPhone == phone);
                        {
                            ;
                            return Ok(ClientRegistartionMapper.ClientConverter(client));
                        }
                    }
                }
            }
            return BadRequest();
        }
    }
}