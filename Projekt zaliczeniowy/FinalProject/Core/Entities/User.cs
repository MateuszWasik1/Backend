using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public int UID { get; set; }
        public string UEmail { get; set; }
        public string UFirstName { get; set; }
        public string ULastName { get; set; }
        public string ULogin { get; set; }
        public string UPassword { get; set; }
        public int RoleId { get; set; } = 1;
        public virtual Role Role { get; set; }

    }
}
