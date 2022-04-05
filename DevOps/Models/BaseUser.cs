using DevOps.Enum;
using Microsoft.AspNetCore.Identity;

namespace DevOps.Models
{
    public class BaseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public AccountType AccountType { get; set; }

    }
}
