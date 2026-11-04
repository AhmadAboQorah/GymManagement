using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Member : BaseEntity
    {
        [Required(ErrorMessage = "Full name is required"),
       StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required"),
       RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public int UserId { get; set; }

        public ApplicationUser? User { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }

        public ICollection<ClassReservation>? Reservations { get; set; }
       

    }
}
