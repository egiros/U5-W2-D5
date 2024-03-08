using System.ComponentModel.DataAnnotations;

namespace U5_W2_D5.Models
{
    public enum Descrizione
    {
        [Display(Name = "Colazione in camera")]
        ColazioneInCamera,
        [Display(Name = "Bevande e cibo")]
        BevandeECibo,
        [Display(Name = "Internet")]
        Internet,
        [Display(Name = "Letto aggiuntivo")]
        LettoAggiuntivo,
        [Display(Name = "Culla")]
        Culla,
    }
}
