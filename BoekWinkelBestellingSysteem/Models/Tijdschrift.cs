using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
// Validatie Boek Klasse
namespace BoekwinkelBestellingssysteem.Models
{
    public class Tijdschrift : Boek
    {
        private Verschijningsperiode verschijningsperiode;

        public Verschijningsperiode VerschijningsPeriode
        {
            get { return verschijningsperiode; }
            set { verschijningsperiode = value; }
        }

        // Constructors
        public Tijdschrift() : base()
        {
            verschijningsperiode = Verschijningsperiode.Wekelijks;
        }

        public Tijdschrift(string isbn, string naam, string uitgever, decimal prijs,
                          Verschijningsperiode periode) : base(isbn, naam, uitgever, prijs)
        {
            verschijningsperiode = periode;
        }

        // Overloaded ToString
        public override string ToString()
        {
            return base.ToString() + $"\nVerschijningsperiode: {verschijningsperiode}";
        }

        // Overloaded Lees methode
        public override void Lees()
        {
            base.Lees();

            Console.WriteLine("\nKies verschijningsperiode:");
            Console.WriteLine("1. Dagelijks");
            Console.WriteLine("2. Wekelijks");
            Console.WriteLine("3. Maandelijks");
            Console.Write("Keuze: ");

            int keuze;
            while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > 3)
            {
                Console.Write("Ongeldige keuze. Kies 1-3: ");
            }

            verschijningsperiode = (Verschijningsperiode)(keuze - 1);
        }
    }
}
