using Domain.Entities;
using Domain.Enums;

public class WorkoutClass : BaseEntity
{
    public string ClassName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty; 

    public int TrainerId { get; set; }

    public int Capacity { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public ClassLevel Level { get; set; }


    public Trainer? Trainer { get; set; }

    public ICollection<ClassReservation>? Reservations { get; set; }
}