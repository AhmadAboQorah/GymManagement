using System.ComponentModel.DataAnnotations;

namespace Trainer
{
    public class Class1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required"),
        StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string? FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required"),
        RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
        [
       Required(ErrorMessage = "Email is required"),
       EmailAddress(ErrorMessage = "Invalid email address")
       ]
        public string? Email { get; set; }
        public int Specialty { get; set; }
        public int ExperienceYears { get; set; }
        public decimal Salary { get; set; }
        public int MyProperty7 { get; set; }
        public int MyProperty8 { get; set; }
        public int MyProperty9 { get; set; }
        public int MyProperty10 { get; set; }

    }
}
