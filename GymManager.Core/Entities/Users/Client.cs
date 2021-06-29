using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymManager.Core.Entities
{
    public class Client : User
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public DateTime LastEntrance { get; set; }
    }
}
