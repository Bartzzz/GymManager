using System;
using System.Collections.Generic;

namespace GymManager.Core.Entities
{
    public class Client : User
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public DateTime LastEntrance { get; set; }
    }
}
