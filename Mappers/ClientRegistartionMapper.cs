using AHRestAPI.Models;
using AHRestAPI.ModelsDTO;
using AnimalHouseRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class ClientRegistartionMapper
    {
        public static Client ClientConverter(ClientResponseLogin clientRegistrationDTO)
        {
            Client client = new Client();
            client.ClientPhone = (decimal)clientRegistrationDTO.ClientPhone;
            client.ClientPassword = clientRegistrationDTO.ClientPassword;
            client.ClientId = (int)clientRegistrationDTO.ID;
            client.ClientCountoforders = clientRegistrationDTO.ClientCountoforders;
            client.ClientName = clientRegistrationDTO.ClientName;
            client.ClientEmail = clientRegistrationDTO.ClientEmail;
            return client;
        }

        public static ClientResponseLogin ClientConverter(Client client)
        {
            ClientResponseLogin clientRegistrationDTO = new ClientResponseLogin();
            clientRegistrationDTO.ClientPhone = client.ClientPhone;
            clientRegistrationDTO.ID = client.ClientId;
            clientRegistrationDTO.ClientPassword = client.ClientPassword;
            clientRegistrationDTO.ClientCountoforders = client.ClientCountoforders;
            clientRegistrationDTO.ClientName = client.ClientName;
            clientRegistrationDTO.ClientEmail = client.ClientEmail;
            return clientRegistrationDTO;
        }

        public static Worker DTOtoWorker(WorkerResponseDTO workerResponseDTO)
        {
            Worker worker = new Worker();
            worker.WorkerEmail = workerResponseDTO.WorkerEmail;
            worker.WorkerId = workerResponseDTO.WorkerId;
            worker.WorkerLogin = workerResponseDTO.WorkerLogin;
            worker.WorkerPassword = workerResponseDTO.WorkerPassword;
            worker.WorkerPhone = workerResponseDTO.WorkerPhone;
            worker.WorkerPostid = workerResponseDTO.WorkerPostid;
            worker.WorkerName = workerResponseDTO.WorkerName;
            return worker;
        }

        public static WorkerResponseDTO WorkerToDTO(Worker worker)
        {
            WorkerResponseDTO workerdto = new WorkerResponseDTO();
            workerdto.WorkerEmail = worker.WorkerEmail;
            workerdto.WorkerId = worker.WorkerId;
            workerdto.WorkerLogin = worker.WorkerLogin;
            workerdto.WorkerPassword = worker.WorkerPassword;
            workerdto.WorkerPhone = worker.WorkerPhone;
            workerdto.WorkerPostid = worker.WorkerPostid;
            workerdto.WorkerName = worker.WorkerName;
            return workerdto;
        }
    }
}
