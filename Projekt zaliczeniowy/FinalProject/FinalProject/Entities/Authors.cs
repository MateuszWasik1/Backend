using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Authors
    {
        [Key]
        public int AId { get; set; }
        public Guid AGID { get; set; }
        public string AFirstName { get; set; }
        public string AMiddleName { get; set; }
        public string ALastName { get; set; }
        public string AFullName { get; set; }
    }
}
