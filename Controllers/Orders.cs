using AHRestAPI.Mappers;
using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace AHRestAPI.Controllers
{
    
    [Route("/orders")]
    [ApiController]
    public class Orders : ControllerBase
    {
        JsonSerializerSettings mainSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [HttpGet]
        [Route("/orders/{orderid}")]
        public ActionResult<OrderGetDTO> GetOrderOnId(int orderid)
        {
            List<OrderGetDTO> getDTO = new List<OrderGetDTO>();
            List<Order> orders = DataBaseConnection.Context.Orders.ToList().Where(x=>x.OrderId == orderid).ToList();
            if (orders != null)
            {
                getDTO = OrdergetMapper.ConvertToGet(orders);
                return Content(JsonConvert.SerializeObject(getDTO, mainSettings));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("/orders/orderslist/{clientid}")]
        public ActionResult<List<OrderGetDTO>> GetOrdersList(int clientid)
        {

            List<OrderGetDTO> getDTO = new List<OrderGetDTO>();
            List<Order> orders = DataBaseConnection.Context.Orders.ToList().Where(x => x.ClientId == clientid).ToList();
            if (orders != null)
            {
                getDTO = OrdergetMapper.ConvertToGet(orders);
                return Content(JsonConvert.SerializeObject(getDTO, mainSettings));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/orders/orderslist/")]
        public ActionResult<List<OrderGetDTO>> GetOrdersList()
        {

            List<OrderGetDTO> getDTO = new List<OrderGetDTO>();
            List<Order> orders = DataBaseConnection.Context.Orders.ToList();
            if (orders != null)
            {
                getDTO = OrdergetMapper.ConvertToGet(orders);
                return Content(JsonConvert.SerializeObject(getDTO, mainSettings));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("/orders/statuschange/{orderid}/{statusid}")]
        public ActionResult<Order> OrderStatusChange(int orderid, int statusid) 
        {
            Order order = DataBaseConnection.Context.Orders.ToList().FirstOrDefault(x => x.OrderId == orderid);
            if (order != null)
            {
                order.OrderStatusid = statusid;
                DataBaseConnection.Context.SaveChanges();
                return Content("Статус изменён");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/orders/orderdelete/{orderid}")]
        public ActionResult<Order> OrderDeleteOnId(int orderid)
        {
            List<Order> order = DataBaseConnection.Context.Orders.ToList().Where(x => x.OrderId == orderid).ToList();
            if (order.Count != 0)
            { 
                DataBaseConnection.Context.Orders.RemoveRange(order);
                DataBaseConnection.Context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/orders/addneworder/")]
        public ActionResult<OrderDTO> AddNewOrder([FromBody] OrderDTO orderdto, decimal clientphone, string clientemail, string clientname, string animalname, string animalgen, string animalbreed, double animalweight, double animalheight, int animalold, int typeid )
        {
            int animalbreedid = 0;
            IActionResult AnimalCheck(int clientid)
            {
                List<Animal> animals = DataBaseConnection.Context.Animals.ToList().Where(x=>x.AnimalClientid == clientid).ToList();
                if (animals != null)
                {
                    foreach (Animal animal in animals)
                    {
                        if (animal.AnimalName == animalname)
                        {
                            orderdto.AnimalId = animal.AnimalId;
                            return Ok();
                        }
                    }
                    return BadRequest();
                }
                else
                {
                    List<Animalbreed> breeds = DataBaseConnection.Context.Animalbreeds.ToList();
                    foreach (Animalbreed breed in breeds)
                    {
                        if (animalbreed == breed.AnimalbreedName)
                        {
                            animalbreedid = breed.AnimalbreedId;
                            return Ok(animalbreedid);
                        }
                        else
                        {
                            Animalbreed newbreed = new()
                            {
                                AnimalbreedId = DataBaseConnection.Context.Animalbreeds.Count() + 1,
                                AnimalbreedName = breed.AnimalbreedName,
                                AnimalTypeid = typeid,
                            };
                        }
                        return Ok();
                    }
                    Animal animal = new(){
                        AnimalId = DataBaseConnection.Context.Animals.Count() + 1,
                        AnimalName = animalname,
                        AnimalGen = animalgen,
                        AnimalClientid = clientid,
                        AnimalBreedid = animalbreedid,
                        AnimalHeight = animalheight,
                        AnimalWeight = animalweight,
                        AnimalOld = animalold
                        };
                    return Ok();
                }

            }
            Random random = new Random();
            Client client = DataBaseConnection.Context.Clients.ToList().FirstOrDefault(x => x.ClientPhone == clientphone && x.ClientEmail == clientemail);
            if (orderdto.AdmissionDate < orderdto.IssueDate)
            {
                return BadRequest("wrong dates");
            }
            
            else
            {
                orderdto.OrderNoteId = DataBaseConnection.Context.Orders.Max(x => x.OrderNoteid) + 1;
                if (client != null)
                {
                    orderdto.ClientId = client.ClientId;
                    orderdto.ClientPhone = clientphone;
                orderdto.OrderId = DataBaseConnection.Context.Orders.Max(x => x.OrderId) + 1;
                    AnimalCheck(client.ClientId);
                    orderdto.OrderStatusId = 1;
                    client.ClientCountoforders += 1;
                    DataBaseConnection.Context.Clients.Update(client);
                    DataBaseConnection.Context.Orders.Add(OrdergetMapper.ConvertToOrder(orderdto));
                    DataBaseConnection.Context.SaveChanges();
                    return Ok();
                }
                else
                {
                    Client client1 = new (){  
                        ClientId = DataBaseConnection.Context.Clients.ToList().Max(x => x.ClientId) + 1,
                        ClientEmail = clientemail,
                        ClientPhone = clientphone,
                        ClientCountoforders = 1,
                        ClientImage = null,
                        ClientName = clientname
                    };
                    DataBaseConnection.Context.Clients.Add(client1);
                    orderdto.ClientId = client1.ClientId;
                    orderdto.ClientPhone = clientphone;
                    AnimalCheck(client.ClientId);
                    orderdto.OrderStatusId = 1;
                    DataBaseConnection.Context.Orders.Add(OrdergetMapper.ConvertToOrder(orderdto));
                    orderdto.OrderRating = null;
                    orderdto.OrderReview = null;
                    orderdto.WorkerId = random.Next(1, 10);
                    DataBaseConnection.Context.SaveChanges();
                    return Ok();
                }

                
            }
        }
    }
}
