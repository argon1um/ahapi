using AHRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class ClientRegistartionMapper
    {
        public static Client ClientConverter(ClientRegistrationDTO clientRegistrationDTO)
        {
            Client client = new Client();
            client.ClientLogin = clientRegistrationDTO.ClientLogin;
            client.ClientPhone = clientRegistrationDTO.ClientPhone;
            client.ClientId = clientRegistrationDTO.ID;
            client.ClientName = clientRegistrationDTO.ClientName;
            client.ClientPassword = clientRegistrationDTO.ClientPassword;
            client.ClientEmail = clientRegistrationDTO.ClientEmail;
            return client;
        }

        public static ClientRegistrationDTO ClientConverter(Client client)
        {
            ClientRegistrationDTO clientRegistrationDTO = new ClientRegistrationDTO();
            clientRegistrationDTO.ClientLogin = client.ClientLogin;
            clientRegistrationDTO.ClientPhone = client.ClientPhone;
            clientRegistrationDTO.ID = client.ClientId;
            clientRegistrationDTO.ClientName = client.ClientName;
            clientRegistrationDTO.ClientPassword = client.ClientPassword;
            clientRegistrationDTO.ClientEmail = client.ClientEmail;
            return clientRegistrationDTO;
        }
    }
}
