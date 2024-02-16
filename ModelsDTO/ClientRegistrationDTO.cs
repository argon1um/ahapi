using AnimalHouseRestAPI.Models;

namespace AnimalHouseRestAPI.ModelsDTO
{
    public class ClientRegistrationDTO
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientLogin { get; set; }
        public string ClientPassword { get; set; }
        public decimal ClientPhone { get; set; }
        public string ClientEmail { get; set; }
    }
}
