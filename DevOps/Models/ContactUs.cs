using System.ComponentModel.DataAnnotations;

namespace DevOps.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }


    }
}
