using AHRestAPI.Mappers;
using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;
using ClosedXML.Excel;
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
        [Route("/orders/orderslist/{clientphone}")]
        public ActionResult<List<OrderGetDTO>> GetOrdersList(long clientphone)
        {

            List<OrderGetDTO> getDTO = new List<OrderGetDTO>();
            List<Order> orders = DataBaseConnection.Context.Orders.ToList().Where(x => x.ClientPhone == clientphone).ToList();
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

        [HttpGet]
        [Route("/orders/payedorders")]
        public ActionResult<Order> OrderDeleteOnId()
        {
            List<OrderGetDTO> getDTO = new List<OrderGetDTO>();
            List<Order> orders = DataBaseConnection.Context.Orders.ToList().Where(x => x.OrderStatusid == 2).ToList();
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

        [HttpDelete]
        [Route("/orders/orderdelete")]
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
        [Route("/orders/addneworder")]
        public ActionResult<OrderDTO> AddNewOrder([FromBody] OrderAddDTO orderdto)
        {
            OrderDTO orderDTO = new OrderDTO();
            int animalbreedid = 0;
            IActionResult AnimalCheck(decimal clientphone)
            {
                List<Animal> animals = DataBaseConnection.Context.Animals.ToList().Where(x=>x.AnimalClientphone == clientphone).ToList();
                if (animals != null)
                {
                    foreach (Animal animal in animals)
                    {
                        if (animal.AnimalName.ToLower() == orderdto.animalName.ToLower())
                        {
                            orderDTO.AnimalId = animal.AnimalId;
                            return Ok();
                        }
                    }
                    List<Animalbreed> breeds = DataBaseConnection.Context.Animalbreeds.ToList();
                    foreach (Animalbreed breed in breeds)
                    {
                        if (orderdto.animalBreed.ToLower() == breed.AnimalbreedName.ToLower())
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
                                AnimalTypeid = DataBaseConnection.Context.Animaltypes.ToList().FirstOrDefault(x => x.AnimaltypeName == orderdto.animalType).AnimaltypeId,
                            };
                            DataBaseConnection.Context.Animalbreeds.Add(newbreed);
                            DataBaseConnection.Context.SaveChanges();
                            Animal animalnotbreed = new()
                            {
                                AnimalId = DataBaseConnection.Context.Animals.Count() + 1,
                                AnimalName = orderdto.animalName,
                                AnimalGen = orderdto.animalGen,
                                AnimalClientphone = orderdto.clientPhone,
                                AnimalBreedid = newbreed.AnimalbreedId,
                                AnimalHeight = (double)orderdto.animalHeight,
                                AnimalWeight = (double)orderdto.animalWeight,
                                AnimalOld = orderdto.animalAge,
                               
                            };
                            orderDTO.AnimalId = animalnotbreed.AnimalId;
                            DataBaseConnection.Context.Animals.Add(animalnotbreed);
                            DataBaseConnection.Context.SaveChanges();
                            return Ok();
                        }
                    }
                    Animal animal1 = new()
                    {
                        AnimalId = DataBaseConnection.Context.Animals.Count() + 1,
                        AnimalName = orderdto.animalName,
                        AnimalGen = orderdto.animalGen,
                        AnimalClientphone = orderdto.clientPhone,
                        AnimalBreedid = animalbreedid,
                        AnimalHeight = (double)orderdto.animalHeight,
                        AnimalWeight = (double)orderdto.animalWeight,
                        AnimalOld = orderdto.animalAge
                    };
                    DataBaseConnection.Context.Animals.Add(animal1);
                    DataBaseConnection.Context.SaveChanges();
                    return Ok();
                }
                return BadRequest();

            }
           
            Client client = DataBaseConnection.Context.Clients.ToList().FirstOrDefault(x => x.ClientPhone == orderdto.clientPhone);
            if (orderdto.admDate > orderdto.issueDate)
            {
                return BadRequest("wrong dates");
            }
            
            else
            {
                orderDTO.OrderNoteId = DataBaseConnection.Context.Orders.Max(x => x.OrderNoteid) + 1;
                if (client != null)
                {
                    orderDTO.ClientPhone = orderdto.clientPhone;
                    orderDTO.OrderId = DataBaseConnection.Context.Orders.Max(x => x.OrderId) + 1;
                    AnimalCheck(client.ClientPhone);
                    orderDTO.OrderStatusId = 1;
                    
                    client.ClientCountoforders += 1;
                    orderDTO.AdmissionDate = orderdto.admDate;
                    orderDTO.IssueDate = orderdto.issueDate;
                    orderDTO.RoomId = DataBaseConnection.Context.Rooms.ToList().FirstOrDefault(x => x.RoomNumber == orderdto.roomId).RoomId;
                    Room room = DataBaseConnection.Context.Rooms.FirstOrDefault(x => x.RoomId == orderDTO.RoomId);
                    room.RoomStatusid = 2;
                    DataBaseConnection.Context.Clients.Update(client);
                    DataBaseConnection.Context.Orders.Add(OrdergetMapper.ConvertToOrder(orderDTO));
                    DataBaseConnection.Context.SaveChanges();
                    return Ok();
                }
                else
                {
                    Client client1 = new()
                    {
                        ClientId = DataBaseConnection.Context.Clients.ToList().Max(x => x.ClientId) + 1,
                        ClientPhone = orderdto.clientPhone,
                        ClientCountoforders = 1,
                        ClientName = orderdto.clientName
                    };
                    DataBaseConnection.Context.Clients.Add(client1);
                    orderDTO.ClientPhone = orderdto.clientPhone;
                    AnimalCheck(client1.ClientPhone);
                    orderDTO.OrderStatusId = 1;
                    orderDTO.AdmissionDate = orderdto.admDate;
                    orderDTO.IssueDate = orderdto.issueDate;
                    orderDTO.RoomId = DataBaseConnection.Context.Rooms.ToList().FirstOrDefault(x => x.RoomNumber == orderdto.roomId).RoomId;
                    Room selroom = DataBaseConnection.Context.Rooms.FirstOrDefault(x => x.RoomId == orderDTO.RoomId);
                    selroom.RoomStatusid = 2;
                    
                    DataBaseConnection.Context.Orders.Add(OrdergetMapper.ConvertToOrder(orderDTO));
                    DataBaseConnection.Context.Rooms.Update(selroom);
                    DataBaseConnection.Context.SaveChanges();
                    return Ok();
                }

                
            }
        }
        [HttpPost]
        [Route("/orders/GenerateDoc")]
        public IActionResult CreateDoc([FromBody] OrderAddDTO order)
        {
            string filepath = $"C:/Users/ItzArg/Documents/paydoc_{order.orderId}.xlsx";
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound("Файл не найден.");
            }

            using (var workbook = new XLWorkbook(filepath))
            {
                foreach (var worksheet in workbook.Worksheets)
                {
                    foreach (var cell in worksheet.CellsUsed())
                    {
                        if (cell.Value.ToString().Contains("CLIENTNAME"))
                        {
                            cell.Value = cell.Value.ToString().Replace("CLIENTNAME", order.clientName);
                        }
                        else if (cell.Value.ToString().Contains("ORDERID"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ORDERID", order.orderId.ToString());
                        }
                        else if (cell.Value.ToString().Contains("CLIENTPHONE"))
                        {
                            cell.Value = cell.Value.ToString().Replace("CLIENTPHONE", order.clientPhone.ToString());
                        }
                        else if (cell.Value.ToString().Contains("ADMDATE"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ADMDATE", order.admDate.ToString("d"));
                        }
                        else if (cell.Value.ToString().Contains("ISSUEDATE"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ISSUEDATE", order.issueDate.ToString("d"));
                        }
                        else if (cell.Value.ToString().Contains("CLIENTMAIL"))
                        {
                            cell.Value = cell.Value.ToString().Replace("CLIENTMAIL", "");
                        }
                        else if (cell.Value.ToString().Contains("ANIMALNAME"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ANIMALNAME", order.animalName);
                        }
                        else if (cell.Value.ToString().Contains("ANIMALGEN"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ANIMALGEN", order.animalGen);
                        }
                        else if (cell.Value.ToString().Contains("ANIMALTYPE"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ANIMALTYPE", order.animalType);
                        }
                        else if (cell.Value.ToString().Contains("ANIMALBREED"))
                        {
                            cell.Value = cell.Value.ToString().Replace("ANIMALBREED", order.animalBreed);
                        }
                        else if (cell.Value.ToString().Contains("TOTALDAYS"))
                        {
                            cell.Value = cell.Value.ToString().Replace("TOTALDAYS", (order.issueDate.Day - order.admDate.Day).ToString());
                        }
                        else if (cell.Value.ToString().Contains("TOTALPRICE"))
                        {
                            cell.Value = cell.Value.ToString().Replace("TOTALPRICE", order.Totalprice.ToString());
                        }
                    }
                }
                workbook.SaveAs(filepath);
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ModifiedFile.xlsx");
        }
    }
}
