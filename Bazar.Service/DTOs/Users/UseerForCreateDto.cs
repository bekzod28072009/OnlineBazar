using Bazar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Service.DTOs.Users
{
    public class UseerForCreateDto
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MinLength(5)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        [MaxLength(200)]
        public string Bio { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
