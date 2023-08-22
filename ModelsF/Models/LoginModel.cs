using System.ComponentModel.DataAnnotations;

namespace MVCAnri.Models
{
    public class LoginModel
    {
        [Required]
        public int UserName { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
