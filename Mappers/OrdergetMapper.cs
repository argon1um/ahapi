using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AHRestAPI.Mappers
{
    public class OrdergetMapper
    {
        public static Order ConvertToOrder(OrderDTO order)
        {
            Order order1 = new Order();
            order1.OrderNoteid = order.OrderNoteId;
            order1.OrderId = order.OrderId;
            order1.AnimalId =  order.AnimalId;
            order1.RoomId = order.RoomId;
            order1.IssueDate = order.IssueDate;
            order1.AdmissionDate = order.AdmissionDate;
            order1.OrderStatusid = order.OrderStatusId;
            order1.ClientPhone = order.ClientPhone;
            return order1;

        }

        public static OrderGetDTO ConvertToGet(Order order)
        {
            OrderGetDTO order1 = new OrderGetDTO();
            order1.OrderNoteId = order.OrderNoteid;
            order1.OrderId = order.OrderId;
            order1.AnimalId =(int)order.AnimalId;
            order1.RoomId = (int)order.RoomId;
            order1.IssueDate = (DateOnly)order.IssueDate;
            order1.AdmissionDate = (DateOnly)order.AdmissionDate;
            order1.OrderStatusId = (int)order.OrderStatusid;
            order1.ClientPhone = (decimal)order.ClientPhone;
            return order1;
        }



        public static List<OrderGetDTO> ConvertToGet(List<Order> orders)
        {
           
            List<OrderGetDTO> order1 = new List<OrderGetDTO>();
            try
            {

            foreach (Order order in orders)
            {
                order1.Add(new OrderGetDTO
                {
                    OrderNoteId = order.OrderNoteid,
                    OrderId = order.OrderId,
                    AnimalId = (int)order.AnimalId,
                    OrderStatusId = (int)order.OrderStatusid,
                    AdmissionDate = (DateOnly)order.AdmissionDate,
                    IssueDate = (DateOnly)order.IssueDate,
                    RoomId = (int)order.RoomId,
                    ClientPhone = (decimal)order.ClientPhone
            });
            }
            return order1;
            }
            catch ( Exception ex)
            {
                throw new Exception();
            }

    }
}
}
