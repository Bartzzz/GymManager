using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GymManager.Core.DTOs;
using GymManager.Core.DTOs.Subscriptions;
using GymManager.Core.Enums;
using GymManager.Data;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Core.Services.SubscriptionService
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public IEnumerable<SubscriptionDto> GetSubscriptions(int id = 0)
        {
            var subscriptionEntities = _subscriptionRepository.GetEntities(id);
            return subscriptionEntities != null ? _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptionEntities) : null;
        }

        public ActiveSubscriptionDto GetUserSubscription(int id)
        {
            var userSubscriptions = _subscriptionRepository.GetEntities(id);

            if (userSubscriptions == null || !userSubscriptions.Any())
            {
                return null;
            }

            var activeSubscription = userSubscriptions.OrderByDescending(x => x.StartDate).First();
            var sub = _mapper.Map<ActiveSubscriptionDto>(activeSubscription);
            sub.IsActive = ValidateSubscription(activeSubscription);
            return sub;
        }

        public SubscriptionDto AddSubscription(SubscriptionDto subscription)
        {
            var addedSubscription = _subscriptionRepository.Add(_mapper.Map<Subscription>(subscription));

            return addedSubscription != null ? _mapper.Map<SubscriptionDto>(addedSubscription) : null;
        }

        public SubscriptionDto UpdateSubscription(SubscriptionDto subscription)
        {
            var updatedSubscription = _subscriptionRepository.Update(_mapper.Map<Subscription>(subscription));

            return updatedSubscription != null ? _mapper.Map<SubscriptionDto>(updatedSubscription) : null;
        }

        public SubscriptionDto RemoveSubscription(int subscriptionId)
        {
            var updatedSubscription = _subscriptionRepository.Delete(subscriptionId);

            return updatedSubscription != null ? _mapper.Map<SubscriptionDto>(updatedSubscription) : null;
        }

        private bool ValidateSubscription(Subscription activeSubscription)
        {
            return (activeSubscription.StartDate > DateTime.Now.AddMonths(-1) && (activeSubscription.SubscriptionType == SubscriptionType.Monthly || activeSubscription.EntrancesLeft > 0));
        }
    }
}
