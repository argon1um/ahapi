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
        [Route("/orders/addneworder")]
        public ActionResult<OrderDTO> AddNewOrder([FromBody] OrderDTO orderdto)
        {
            if (orderdto.AdmissionDate < orderdto.IssueDate)
            {
                return BadRequest();
            }
            else
            {
                orderdto.OrderNoteId = DataBaseConnection.Context.Orders.Max(x=>x.OrderNoteid) + 1;
                orderdto.OrderId = DataBaseConnection.Context.Orders.Max(x=>x.OrderId) + 1;
                DataBaseConnection.Context.Orders.Add(OrdergetMapper.ConvertToOrder(orderdto));
                DataBaseConnection.Context.SaveChanges();
                return Ok();
            }
        }
    }
}
