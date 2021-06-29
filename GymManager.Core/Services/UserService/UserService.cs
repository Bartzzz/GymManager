using AutoMapper;
using GymManager.Core.DTOs.Users;
using GymManager.Core.Entities;
using GymManager.Core.Services.SubscriptionService;
using System.Collections.Generic;
using GymManager.Core.DTOs.Subscriptions;

namespace GymManager.Core.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(ISubscriptionService subscriptionService, IUserRepository userRepository, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public IEnumerable<ClientDto> GetClients()
        {
           var clients =  _userRepository.GetEntities();
           var clientDtos = clients != null ? _mapper.Map<IEnumerable<ClientDto>>(clients) : null;

           if (clientDtos == null)
           {
               return null;
           }

           foreach (var userDto in clientDtos)
           {
               userDto.Subscriptions = _subscriptionService.GetSubscriptions(userDto.Id);
           }

           return clientDtos;
        }

        public ClientDto GetClient(int userId)
        {
            var client = _userRepository.GetById(userId);
            var clientDto  = client != null ? _mapper.Map<ClientDto>(client) : null;

            if (clientDto == null)
            {
                return null;
            }

            clientDto.Subscriptions = _subscriptionService.GetSubscriptions(client.Id);

            return clientDto;
        }

        public ClientDto AddClient(ClientDto client)
        {
            var addedClient = _userRepository.Add(_mapper.Map<Client>(client));

            return addedClient != null ? _mapper.Map<ClientDto>(addedClient) : null;
        }

        public ClientDto UpdateClient(ClientDto client)
        {
            var updatedClient = _userRepository.Update(_mapper.Map<Client>(client));

            return updatedClient != null ? _mapper.Map<ClientDto>(updatedClient) : null;
        }

        public ClientDto RemoveClient(int clientId)
        {
            var removedClient = _userRepository.Delete(clientId);

            return removedClient != null ? _mapper.Map<ClientDto>(removedClient) : null;
        }
    }
}