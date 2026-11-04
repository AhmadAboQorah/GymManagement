using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Trainer
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public TrainerSpecialty Specialty { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
}
