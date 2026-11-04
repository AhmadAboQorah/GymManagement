using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Subscription
{
     public class CreateSubscriptionDto
    {
        public int MemberId { get; set; }
        public int MembershipPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
