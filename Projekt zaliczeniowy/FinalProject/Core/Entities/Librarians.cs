using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Librarians
    {
        [Key]
        public int LId { get; set; }
        public string LFirstName { get; set; }
        public string LLastName { get; set; }
        public string LEmail { get; set; }

    }
}
