using AnimalHouseRestAPI.Models;

namespace AnimalHouseRestAPI.ModelsDTO
{
    public class OrderDTO
    {
        public int OrderNoteId { get; set; }
        public int OrderId { get; set; }
        public int RoomId { get; set; }
        public int AnimalId { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly AdmissionDate { get; set; }
        public decimal ClientPhone { get; set; }
        public int OrderStatusId { get; set; }


    }

}
