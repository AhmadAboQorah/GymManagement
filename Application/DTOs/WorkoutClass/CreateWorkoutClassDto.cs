using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.WorkoutClass
{
     public class CreateWorkoutClassDto
    {
        public string ClassName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TrainerId { get; set; }
        public int Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ClassLevel Level { get; set; }
    }
}
