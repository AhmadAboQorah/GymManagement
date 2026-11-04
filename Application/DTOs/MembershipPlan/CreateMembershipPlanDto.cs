using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.MembershipPlan
{
     public class CreateMembershipPlanDto
    {
        public string PlanName { get; set; } = string.Empty;
        public int DurationInMonths { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
