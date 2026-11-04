using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class MembershipPlan : BaseEntity
    {
        public string PlanName { get; set; } = string.Empty;    
        public int DurationInMonths { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<ClassReservation> Reservations { get; set; } = new List<ClassReservation>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    }
}
