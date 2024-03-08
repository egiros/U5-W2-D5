using System.ComponentModel.DataAnnotations;

namespace U5_W2_D5.Models
{
    public class Camera
    {
        public int ID { get; set; }
        [Display(Name = "N° Stanza")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public int Numero { get; set; }
        [Display(Name = "Descrizione")]
        public string? Descrizione { get; set; }
        [Display(Name = "Doppia")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public bool Doppia { get; set; }
        [Display(Name = "Disponibilità")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public bool Disponibilita { get; set; }

    }
}
