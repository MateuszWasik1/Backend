using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Books
    {
        [Key]
        public int BId { get; set; }
        public string BTitle { get; set; }
        public string BISBN { get; set; }
        public DateTime BPublishDate { get; set; }
        public List<Authors> BAuthors { get; set; }
    }
}
