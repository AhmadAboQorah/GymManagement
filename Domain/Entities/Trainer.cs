using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Trainer : BaseEntity
    {
        [Required(ErrorMessage = "Full name is required"),
        StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required"),
        RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;
        [
       Required(ErrorMessage = "Email is required"),
       EmailAddress(ErrorMessage = "Invalid email address")
       ]
        public string Email { get; set; } = string.Empty;
        public TrainerSpecialty Specialty { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<WorkoutClass> WorkoutClasses { get; set; } = new List<WorkoutClass>();

    }
}
