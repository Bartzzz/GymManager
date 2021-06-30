using GymManager.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GymManager.Core.Entities
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public int EntrancesLeft { get; set; }

        public int UserId { get; set; }
        public Client User { get; set; }
    }
}
