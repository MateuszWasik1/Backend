using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RegisterUserDTO
    {
        public string UEmail { get; set; }
        public string UFirstName { get; set; }
        public string ULastName { get; set; }
        public string ULogin { get; set; }
        public string UPassword { get; set; }
        public string UPasswordConfirmed { get; set; }
        public int Role { get; set; } = 1; //1 = User
    }
}
