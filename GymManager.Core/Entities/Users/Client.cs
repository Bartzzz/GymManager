using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Core.Entities
{
    public class Client : User
    {
        public Subscription Subscription { get; set; }
    }
}
