using System.ComponentModel.DataAnnotations;

namespace DevOps.ViewModels.Accounts
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
