using GymManager.Core.Enums;
using System;

namespace GymManager.Core.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public int EntrncesLeft { get; set; }
    }
}
