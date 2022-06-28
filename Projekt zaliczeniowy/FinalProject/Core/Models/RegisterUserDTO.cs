using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RegisterUserDTO
    {
        [Required]
        public string UEmail { get; set; }

        [Required]
        public string UFirstName { get; set; }

        [Required]
        public string ULastName { get; set; }

        [Required]
        public string ULogin { get; set; }

        [Required]
        [MinLength(8)]
        public string UPassword { get; set; }

        public int Role { get; set; } = 1; //1 = User
    }
}
