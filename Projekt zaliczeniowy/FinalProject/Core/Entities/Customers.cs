using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Customers
    {
        [Key]
        public int CId { get; set; }
        public string CFirstName { get; set; }
        public string CLastName { get; set; }
        public int CCardCode { get; set; }

        //public List<Books> CBooks { get; set; }

    }
}
