using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ClassReservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int WorkoutClassId { get; set; }
        public DateTime ReservationDate { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
    }
}
