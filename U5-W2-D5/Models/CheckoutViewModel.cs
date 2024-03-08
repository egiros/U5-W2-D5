using U5_W2_D5.Migrations;

namespace U5_W2_D5.Models
{
    public class CheckoutViewModel
    {
        public Prenotazione Prenotazione { get; set; }
        public List<Servizi> Servizi { get; set; }
    }
}
