using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BoekwinkelBestellingssysteem.Orders
{
    public class BestellingEventArgs : EventArgs
    {
        public int BestellingId { get; set; }
        public string ItemNaam { get; set; }
        public decimal TotaalPrijs { get; set; }

        public BestellingEventArgs(int id, string naam, decimal prijs)
        {
            BestellingId = id;
            ItemNaam = naam;
            TotaalPrijs = prijs;
        }
    }
}
