using DevOps.Enum;
using System.ComponentModel.DataAnnotations;

namespace DevOps.ViewModels.Accounts
{
    public class RegisterDto
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public AccountType BaseUserType { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password isn't match with Password field")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
