namespace AHRestAPI.ModelsDTO
{
    public class ServiceDTO
    {
        public int ServiceId { get; set; }

        public int? ServiceCategid { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public double? ServicePrice { get; set; }
    }
}
