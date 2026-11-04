using Domain.Entities;
using Domain.Enums;

public class ClassReservation : BaseEntity
{
    public int MemberId { get; set; }

    public int WorkoutClassId { get; set; }

    public int MembershipPlanId { get; set; }

    public DateTime ReservationDate { get; set; }

    public AttendanceStatus AttendanceStatus { get; set; }

    public Member? Member { get; set; }

    public WorkoutClass? WorkoutClass { get; set; }

    public MembershipPlan? MembershipPlan { get; set; }
}