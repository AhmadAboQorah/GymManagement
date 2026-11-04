using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Subscription
{
     public class UpdateSubscriptionDto
    {
        public int MembershipPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }
        public int MemberId { get; internal set; }
    }
}
