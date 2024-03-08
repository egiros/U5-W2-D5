using System.ComponentModel.DataAnnotations;

namespace U5_W2_D5.Models
{
    public class Pensione
    {
        public int ID { get; set; }
        [Display(Name = "Pensione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Tipologia { get; set; }
        [Display(Name = "Prezzo")]

        public Decimal? Prezzo { get; set; }
    }
}
