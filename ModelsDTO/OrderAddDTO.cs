namespace AHRestAPI.ModelsDTO
{
    public class OrderAddDTO
    {
        public int orderNoteId { get; set; }
        public int orderId { get; set; }
        public DateOnly admDate { get; set; }
        public DateOnly issueDate { get; set; }
        public decimal clientPhone { get; set; }
        public string clientName { get; set; }
        public int roomId { get; set; }
        public string animalType { get; set; }
        public string animalBreed { get; set; }
        public string animalName { get; set; }
        public int animalAge { get; set; }
        public decimal animalWeight { get; set; }
        public decimal animalHeight { get; set;}
        public string animalGen { get; set; }
		public int? Totalprice { get; set; }
	}
}
