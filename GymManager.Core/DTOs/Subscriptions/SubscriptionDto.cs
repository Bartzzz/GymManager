using System;
using GymManager.Core.Enums;

namespace GymManager.Core.DTOs.Subscriptions
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public int EntrancesLeft { get; set; }
        public int UserId { get; set; }
    }
}
