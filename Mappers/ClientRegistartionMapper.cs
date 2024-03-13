using AHRestAPI.Models;
using AnimalHouseRestAPI.ModelsDTO;

namespace AHRestAPI.Mappers
{
    public class ClientRegistartionMapper
    {
        public static Client ClientConverter(ClientResponseLogin clientRegistrationDTO)
        {
            Client client = new Client();
            client.ClientLogin = clientRegistrationDTO.ClientLogin;
            client.ClientPhone = (decimal)clientRegistrationDTO.ClientPhone;
            client.ClientId = (int)clientRegistrationDTO.ID;
            client.ClientName = clientRegistrationDTO.ClientName;
            client.ClientPassword = clientRegistrationDTO.ClientPassword;
            client.ClientEmail = clientRegistrationDTO.ClientEmail;
            return client;
        }

        public static ClientResponseLogin ClientConverter(Client client)
        {
            ClientResponseLogin clientRegistrationDTO = new ClientResponseLogin();
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
