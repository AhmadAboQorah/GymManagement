using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {
        [Required(ErrorMessage = "Full name is required"),
        StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string FullName { get; set; } = string.Empty;
        [
        Required(ErrorMessage = "Email is required"),
        EmailAddress(ErrorMessage = "Invalid email address")
        ]
        public string Email { get; set; } = string.Empty;
        [Required,
        MinLength(8, ErrorMessage = "Password must be at least 8 characters."),
        RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number and special character.")]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        [Required(ErrorMessage = "Phone number is required"),
        RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = false;

        public Member? Member { get; set; }

        public Trainer? Trainer { get; set; }
        






    }
}
