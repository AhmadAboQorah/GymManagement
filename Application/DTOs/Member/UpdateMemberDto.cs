using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Member
{
     public class UpdateMemberDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
