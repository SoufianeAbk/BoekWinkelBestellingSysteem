using System;
using System.Collections.Generic;
using BoekwinkelBestellingssysteem.Models;
using BoekwinkelBestellingssysteem.Orders;

namespace BoekwinkelBestellingssysteem
{
    class Program
    {
        static List<Boek> boeken = new List<Boek>();
        static List<Tijdschrift> tijdschriften = new List<Tijdschrift>();
        static List<object> bestellingen = new List<object>();

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║   BOEKWINKEL BESTELLINGSSYSTEEM                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            // Initialiseer testdata
            InitialiseerTestData();

            bool doorgaan = true;
            while (doorgaan)
            {
                ToonHoofdMenu();
                string keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        ToonBoeken();
                        break;
                    case "2":
                        ToonTijdschriften();
                        break;
                    case "3":
                        VoegBoekToe();
                        break;
                    case "4":
                        VoegTijdschriftToe();
                        break;
                    case "5":
                        BestelBoek();
                        break;
                    case "6":
                        BestelTijdschrift();
                        break;
                    case "7":
                        ToonBestellingen();
                        break;
                    case "8":
                        doorgaan = false;
                        Console.WriteLine("\n✓ Bedankt voor uw bezoek!");
                        break;
                    default:
                        Console.WriteLine("\n✗ Ongeldige keuze. Probeer opnieuw.");
                        break;
                }

                if (doorgaan)
                {
                    Console.WriteLine("\n[Druk op een toets om verder te gaan...]");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ToonHoofdMenu()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   HOOFDMENU                        ║");
            Console.WriteLine("╠════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Toon alle boeken                               ║");
            Console.WriteLine("║  2. Toon alle tijdschriften                        ║");
            Console.WriteLine("║  3. Voeg nieuw boek toe                            ║");
            Console.WriteLine("║  4. Voeg nieuw tijdschrift toe                     ║");
            Console.WriteLine("║  5. Bestel boek                                    ║");
            Console.WriteLine("║  6. Bestel tijdschrift (abonnement)                ║");
            Console.WriteLine("║  7. Toon alle bestellingen                         ║");
            Console.WriteLine("║  8. Afsluiten                                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.Write("\nUw keuze: ");
        }

        static void InitialiseerTestData()
        {
            // Maak 5 boeken aan
            boeken.Add(new Boek("978-0-13-468599-1", "Clean Code", "Prentice Hall", 35.99m));
            boeken.Add(new Boek("978-0-201-63361-0", "Design Patterns", "Addison-Wesley", 42.50m));
            boeken.Add(new Boek("978-0-13-235088-4", "Clean Architecture", "Prentice Hall", 38.75m));
            boeken.Add(new Boek("978-0-13-597830-2", "Agile Software Development", "Pearson", 44.99m));
            boeken.Add(new Boek("978-0-321-12742-6", "Domain-Driven Design", "Addison-Wesley", 49.99m));

            // Maak 5 tijdschriften aan
            tijdschriften.Add(new Tijdschrift("ISSN-1234-5678", "Tech Weekly", "Tech Publishers", 8.50m, Verschijningsperiode.Wekelijks));
            tijdschriften.Add(new Tijdschrift("ISSN-2345-6789", "Daily News", "News Corp", 5.00m, Verschijningsperiode.Dagelijks));
            tijdschriften.Add(new Tijdschrift("ISSN-3456-7890", "Programming Monthly", "Dev Media", 12.99m, Verschijningsperiode.Maandelijks));
            tijdschriften.Add(new Tijdschrift("ISSN-4567-8901", "Science Today", "Science Press", 15.50m, Verschijningsperiode.Wekelijks));
            tijdschriften.Add(new Tijdschrift("ISSN-5678-9012", "Business Magazine", "Business Ltd", 18.75m, Verschijningsperiode.Maandelijks));

            Console.WriteLine(" 5 boeken en 5 tijdschriften geladen.\n");
        }

        static void ToonBoeken()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 ALLE BOEKEN                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            if (boeken.Count == 0)
            {
                Console.WriteLine("Geen boeken beschikbaar.");
                return;
            }

            for (int i = 0; i < boeken.Count; i++)
            {
                Console.WriteLine($"─────────────────── [{i + 1}] ───────────────────");
                Console.WriteLine(boeken[i]);
                Console.WriteLine();
            }
        }

        static void ToonTijdschriften()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ALLE TIJDSCHRIFTEN                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            if (tijdschriften.Count == 0)
            {
                Console.WriteLine("Geen tijdschriften beschikbaar.");
                return;
            }

            for (int i = 0; i < tijdschriften.Count; i++)
            {
                Console.WriteLine($"─────────────────── [{i + 1}] ───────────────────");
                Console.WriteLine(tijdschriften[i]);
                Console.WriteLine();
            }
        }

        static void VoegBoekToe()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║            NIEUW BOEK TOEVOEGEN                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            Boek nieuwBoek = new Boek();
            nieuwBoek.Lees();
            boeken.Add(nieuwBoek);
            Console.WriteLine("\n✓ Boek succesvol toegevoegd!");
        }

        static void VoegTijdschriftToe()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║         NIEUW TIJDSCHRIFT TOEVOEGEN                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            Tijdschrift nieuwTijdschrift = new Tijdschrift();
            nieuwTijdschrift.Lees();
            tijdschriften.Add(nieuwTijdschrift);
            Console.WriteLine("\n✓ Tijdschrift succesvol toegevoegd!");
        }

        static void BestelBoek()
        {
            if (boeken.Count == 0)
            {
                Console.WriteLine("\n✗ Geen boeken beschikbaar om te bestellen.");
                return;
            }

            ToonBoeken();
            Console.Write("Kies een boek (nummer): ");
            int keuze;
            if (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > boeken.Count)
            {
                Console.WriteLine("✗ Ongeldige keuze.");
                return;
            }

            Console.Write("Aantal exemplaren: ");
            int aantal;
            if (!int.TryParse(Console.ReadLine(), out aantal) || aantal < 1)
            {
                Console.WriteLine("✗ Ongeldig aantal.");
                return;
            }

            Boek gekozenBoek = boeken[keuze - 1];
            Bestelling<Boek> bestelling = new Bestelling<Boek>(gekozenBoek, aantal);

            // Abonneer op event
            bestelling.BestellingGeplaatst += BestellingBevestiging;

            // Plaats bestelling
            var resultaat = bestelling.Bestel();

            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║           BESTELLING GEPLAATST                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine($"ISBN:        {resultaat.Item1}");
            Console.WriteLine($"Aantal:      {resultaat.Item2}");
            Console.WriteLine($"Totaalprijs: €{resultaat.Item3:F2}");

            bestellingen.Add(bestelling);
        }

        static void BestelTijdschrift()
        {
            if (tijdschriften.Count == 0)
            {
                Console.WriteLine("\n✗ Geen tijdschriften beschikbaar om te bestellen.");
                return;
            }

            ToonTijdschriften();
            Console.Write("Kies een tijdschrift (nummer): ");
            int keuze;
            if (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > tijdschriften.Count)
            {
                Console.WriteLine("✗ Ongeldige keuze.");
                return;
            }

            Console.Write("Aantal exemplaren: ");
            int aantal;
            if (!int.TryParse(Console.ReadLine(), out aantal) || aantal < 1)
            {
                Console.WriteLine("✗ Ongeldig aantal.");
                return;
            }

            Console.Write("Abonnement voor hoeveel maanden? ");
            int maanden;
            if (!int.TryParse(Console.ReadLine(), out maanden) || maanden < 1)
            {
                Console.WriteLine("✗ Ongeldig aantal maanden.");
                return;
            }

            Tijdschrift gekozenTijdschrift = tijdschriften[keuze - 1];
            Bestelling<Tijdschrift> bestelling = new Bestelling<Tijdschrift>(gekozenTijdschrift, aantal, maanden);

            // Abonneer op event
            bestelling.BestellingGeplaatst += BestellingBevestiging;

            // Plaats bestelling
            var resultaat = bestelling.Bestel();

            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║           ABONNEMENT GEPLAATST                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
            Console.WriteLine($"ISBN:        {resultaat.Item1}");
            Console.WriteLine($"Aantal:      {resultaat.Item2}");
            Console.WriteLine($"Periode:     {maanden} maanden");
            Console.WriteLine($"Totaalprijs: €{resultaat.Item3:F2}");

            bestellingen.Add(bestelling);
        }

        static void BestellingBevestiging(object sender, BestellingEventArgs e)
        {
            Console.WriteLine($"\n★★★ BEVESTIGING: Bestelling #{e.BestellingId} voor '{e.ItemNaam}' is geplaatst! Totaal: €{e.TotaalPrijs:F2} ★★★");
        }

        static void ToonBestellingen()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ALLE BESTELLINGEN                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝");

            if (bestellingen.Count == 0)
            {
                Console.WriteLine("\nGeen bestellingen gevonden.");
                return;
            }

            foreach (var bestelling in bestellingen)
            {
                Console.WriteLine(bestelling.ToString());
                Console.WriteLine("════════════════════════════════════════════════════");
            }
        }
    }
}