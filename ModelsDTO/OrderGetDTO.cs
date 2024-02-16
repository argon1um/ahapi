using AnimalHouseRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;
using System.Collections.Generic;

namespace AHRestAPI.ModelsDTO
{
    public class OrderGetDTO
    {
        public int OrderNoteId { get; set; }
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int AnimalId { get; set; }
        public int RoomId { get; set; }
        public int WorkerId { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly AdmissionDate { get; set; }
        public int OrderStatusId { get; set; }


    }
}
