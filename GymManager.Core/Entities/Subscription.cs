using GymManager.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public int EntrncesLeft { get; set; }

        public int UserId { get; set; }
        public Client User { get; set; }
    }
}
