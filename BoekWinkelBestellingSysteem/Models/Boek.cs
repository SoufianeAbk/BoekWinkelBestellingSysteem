using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace BoekwinkelBestellingssysteem.Models
{
    public class Boek
    {
        private string isbn;
        private string naam;
        private string uitgever;
        private decimal prijs;

        // Properties met gepersonaliseerde getters/setters voor prijs
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string Uitgever
        {
            get { return uitgever; }
            set { uitgever = value; }
        }

        public decimal Prijs
        {
            get { return prijs; }
            set
            {
                // Prijs is tussen 5€ en 50€ zijn
                if (value < 5)
                    prijs = 5;
                else if (value > 50)
                    prijs = 50;
                else
                    prijs = value;
            }
        }

        // Constructors
        public Boek()
        {
            isbn = "";
            naam = "";
            uitgever = "";
            prijs = 5;
        }

        public Boek(string isbn, string naam, string uitgever, decimal prijs)
        {
            this.isbn = isbn;
            this.naam = naam;
            this.uitgever = uitgever;
            this.Prijs = prijs; // Gebruik property voor validatie
        }

        // Overloaded ToString
        public override string ToString()
        {
            return $"ISBN: {isbn}\nNaam: {naam}\nUitgever: {uitgever}\nPrijs: €{prijs:F2}";
        }

        // Basis ingeefmethode
        public virtual void Lees()
        {
            Console.Write("Geef ISBN in: ");
            isbn = Console.ReadLine();

            Console.Write("Geef naam in: ");
            naam = Console.ReadLine();

            Console.Write("Geef uitgever in: ");
            uitgever = Console.ReadLine();

            Console.Write("Geef prijs in (€5-€50): ");
            while (!decimal.TryParse(Console.ReadLine(), out prijs))
            {
                Console.Write("Ongeldige invoer. Geef prijs in: ");
            }
            // Property setter zorgt voor validatie
            Prijs = prijs;
        }
    }
}
