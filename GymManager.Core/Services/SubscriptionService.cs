using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Core.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        public SubscriptionService(AppDbContext context)
        {

        }
        public IEnumerable<Subscription> GetSubscriptions()
        {
            throw new NotImplementedException();
        }
    }
}
