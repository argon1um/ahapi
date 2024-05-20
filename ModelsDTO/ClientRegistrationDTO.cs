using AnimalHouseRestAPI.Models;

namespace AnimalHouseRestAPI.ModelsDTO
{
    public class ClientResponseLogin
    {
        public int? ID { get; set; }
        public string? ClientName { get; set; }
        public decimal ClientPhone { get; set; }
        public string ClientPassword { get; set; }
        public string? ClientEmail { get; set; }
        public int? ClientCountoforders { get; set; }
    }
}
