﻿using AHRestAPI.Models;
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
    }
}
