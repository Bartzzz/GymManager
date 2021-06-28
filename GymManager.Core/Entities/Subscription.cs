using GymManager.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        //public bool IsActive { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int EntrncesLeft { get; set; }

        public int UserId { get; set; }
        public Client User { get; set; }
    }
}
