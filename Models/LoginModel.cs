using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        [MinLength(6,ErrorMessage ="Password must be 6 symbols lenght")]
        public string Password { get; set; }
    }
}
