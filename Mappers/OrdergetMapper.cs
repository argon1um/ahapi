using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class OrdergetMapper
    {
        public static Order ConvertToOrder(OrderDTO order)
        {
            Order order1 = new Order();
            order1.OrderNoteid = order.OrderNoteId;
            order1.OrderId = order.OrderId;
            order1.ClientId = order.ClientId;
            order1.AnimalId =  order.AnimalId;
            order1.RoomId = order.RoomId;
            order1.WorkerId = order.WorkerId;
            order1.IssueDate = order.IssueDate;
            order1.AdmissionDate = order.AdmissionDate;
            order1.OrderStatusid = order.OrderStatusId;
            return order1;

        }

        public static OrderGetDTO ConvertToGet(Order order)
        {
            OrderGetDTO order1 = new OrderGetDTO();
            order1.OrderNoteId = order.OrderNoteid;
            order1.OrderId = order.OrderId;
            order1.AnimalId =(int)order.AnimalId;
            order1.ClientId = (int)order.ClientId;
            order1.RoomId = (int)order.RoomId;
            order1.WorkerId = (int)order.WorkerId;
            order1.IssueDate = (DateOnly)order.IssueDate;
            order1.AdmissionDate = (DateOnly)order.AdmissionDate;
            order1.OrderStatusId = (int)order.OrderStatusid;
            return order1;
        }



        public static List<OrderGetDTO> ConvertToGet(List<Order> orders)
        {
            List<OrderGetDTO> order1 = new List<OrderGetDTO>();
            foreach (Order order in orders)
            {
                order1.Add(new OrderGetDTO
                {
                    OrderNoteId = order.OrderNoteid,
                    OrderId = order.OrderId,
                    ClientId = (int)order.ClientId,
                    AnimalId = (int)order.AnimalId,
                    OrderStatusId = (int)order.OrderStatusid,
                    AdmissionDate = (DateOnly)order.AdmissionDate,
                    IssueDate = (DateOnly)order.IssueDate,
                    RoomId = (int)order.RoomId,
                    WorkerId = (int)order.WorkerId
                });
            }
            return order1;
        }
    }
}
