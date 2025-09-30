using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using BoekwinkelBestellingssysteem.Models;

namespace BoekwinkelBestellingssysteem.Orders
{
    public class Bestelling<T> where T : Boek
    {
        private static int volgNummer = 0;
        private int id;
        private T item;
        private DateTime datum;
        private int aantal;
        private int? abonnementMaanden; // Nullable voor tijdschriften-abonnement

        // Event voor bestellingsbevestiging
        public event EventHandler<BestellingEventArgs> BestellingGeplaatst;
        public int Id
        {
            get { return id; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public int Aantal
        {
            get { return aantal; }
            set { aantal = value; }
        }

        public int? AbonnementMaanden
        {
            get { return abonnementMaanden; }
            set { abonnementMaanden = value; }
        }

        // Constructor met uniek volgnummer
        public Bestelling(T item, int aantal, int? abonnementMaanden = null)
        {
            this.id = ++volgNummer; // Uniek volgnummer
            this.item = item;
            this.datum = DateTime.Now;
            this.aantal = aantal;
            this.abonnementMaanden = abonnementMaanden;
        }

        // Tuple methode Bestel
        public Tuple<string, int, decimal> Bestel()
        {
            decimal totaalPrijs = item.Prijs * aantal;

            // Als het een abonnement is, vermenigvuldig met aantal maanden
            if (abonnementMaanden.HasValue)
            {
                totaalPrijs *= abonnementMaanden.Value;
            }

            // Trigger event
            OnBestellingGeplaatst(new BestellingEventArgs(id, item.Naam, totaalPrijs));

            // Retourneer tuple met ISBN, aantal en totale prijs
            return Tuple.Create(item.Isbn, aantal, totaalPrijs);
        }

        protected virtual void OnBestellingGeplaatst(BestellingEventArgs e)
        {
            BestellingGeplaatst?.Invoke(this, e);
        }

        public override string ToString()
        {
            string info = $"\n=== BESTELLING #{id} ===\n";
            info += $"Datum: {datum:dd/MM/yyyy HH:mm}\n";
            info += $"Aantal: {aantal}\n";
            if (abonnementMaanden.HasValue)
            {
                info += $"Abonnement periode: {abonnementMaanden.Value} maanden\n";
            }
            info += $"\nItem details:\n{item}\n";
            info += $"\nTotaal: €{(abonnementMaanden.HasValue ? item.Prijs * aantal * abonnementMaanden.Value : item.Prijs * aantal):F2}";
            return info;
        }
    }
}

