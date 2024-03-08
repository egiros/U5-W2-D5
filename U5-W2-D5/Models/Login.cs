using System.ComponentModel.DataAnnotations;
namespace U5_W2_D5.Models
{
    public class Login
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Username obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo Password obbligatorio")]
        public string Password { get; set; }
    }
}
