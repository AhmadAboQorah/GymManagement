using Domain.Entities;
using Domain.Enums;

public class Subscription : BaseEntity
{
    public int MemberId { get; set; }

    public int MembershipPlanId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public SubscriptionStatus Status { get; set; }


    public Member? Member { get; set; }

    public MembershipPlan? MembershipPlan { get; set; }
}