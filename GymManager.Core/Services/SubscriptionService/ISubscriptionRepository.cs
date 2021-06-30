using GymManager.Core.Entities;
using GymManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Core.Services.SubscriptionService
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
    }
}
