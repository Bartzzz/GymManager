using GymManager.Core.DTOs.Subscriptions;
using System;
using System.Collections.Generic;

namespace GymManager.Core.DTOs.Users
{
    public class ClientDto : UserDto
    {
        public DateTime LastEntrance { get; set; }
        public IEnumerable<SubscriptionDto> Subscriptions { get; set; }
    }
}
