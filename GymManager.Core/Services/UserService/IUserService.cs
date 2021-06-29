using System.Collections.Generic;
using GymManager.Core.DTOs.Users;
using GymManager.Core.Entities;

namespace GymManager.Core.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<ClientDto> GetClients();
        ClientDto GetClient(int userId);
        ClientDto AddClient(ClientDto client);
        ClientDto UpdateClient(ClientDto client);
        ClientDto RemoveClient(int clientId);
    }
}
