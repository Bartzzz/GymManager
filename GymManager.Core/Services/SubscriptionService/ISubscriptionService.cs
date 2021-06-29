using GymManager.Core.DTOs;
using System.Collections.Generic;
using GymManager.Core.DTOs.Subscriptions;
using GymManager.Core.Entities;

namespace GymManager.Core.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        IEnumerable<SubscriptionDto> GetSubscriptions(int id = 0);
        ActiveSubscriptionDto GetUserSubscription(int userId);
        SubscriptionDto AddSubscription(SubscriptionDto subscription);
        SubscriptionDto UpdateSubscription(SubscriptionDto subscription);
        SubscriptionDto RemoveSubscription(int subscriptionId);
    }
}
