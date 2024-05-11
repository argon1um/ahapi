using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class ServicesMapper
    {
        public static Service ConvertToService(ServiceDTO serviceDTO)
        {
            Service service = new Service();
            service.ServiceId = serviceDTO.ServiceId;
            service.ServicePrice = serviceDTO.ServicePrice;
            service.ServiceCategid = serviceDTO.ServiceCategid;
            service.ServiceDescription = serviceDTO.ServiceDescription;
            service.ServiceName = serviceDTO.ServiceName;
            service.ServiceImage = serviceDTO.Serviceimage;
            return service;

        }

        public static ServiceDTO ConvertToServiceDTO(Service service)
        {
            ServiceDTO serviceDTO = new ServiceDTO();
            serviceDTO.ServiceId = service.ServiceId;
            serviceDTO.ServicePrice = service.ServicePrice;
            serviceDTO.ServiceCategid = service.ServiceCategid;
            serviceDTO.ServiceDescription = service.ServiceDescription;
            serviceDTO.ServiceName = service.ServiceName;
            serviceDTO.Serviceimage = service.ServiceImage;
            return serviceDTO;
        }



        public static List<ServiceDTO> ConvertToServiceDTO(List<Service> services)
        {
            List<ServiceDTO> servicelist = new List<ServiceDTO>();
            foreach (Service service in services)
            {
                servicelist.Add(new ServiceDTO
                {
                    ServiceId = service.ServiceId,
                    ServicePrice = service.ServicePrice,
                    ServiceCategid = service.ServiceCategid,
                    ServiceDescription = service.ServiceDescription,
                    ServiceName = service.ServiceName,
                    Serviceimage = service.ServiceImage
                });
            }
            return servicelist;
        }

    }
}
