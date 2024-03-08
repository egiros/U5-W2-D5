using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace U5_W2_D5.Models
{
    public class Servizi
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Display(Name = "Descrizione")]
        public Descrizione Descrizione { get; set; }
        [Display(Name = "Prezzo")]
        public double? Prezzo { get; set; }

        [Display(Name = "Data Richiesta Servizio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRichiestaServizio { get; set; }

        [Display(Name = "Prenotazione")]
        [ForeignKey("Prenotazione")]
        public int IDPrenotazione { get; set; }
        public Prenotazione? Prenotazione { get; set; }

    }
}
