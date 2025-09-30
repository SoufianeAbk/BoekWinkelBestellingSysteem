Hoofdfunctionaliteiten
Menu opties:

Toon alle boeken - Catalogus met ISBN, naam, uitgever en prijs
Toon alle tijdschriften - Met verschijningsperiode
Voeg nieuw boek toe - Interactieve invoer van boekgegevens
Voeg nieuw tijdschrift toe - Inclusief keuze voor periode
Bestel boek - Kies boek en aantal exemplaren
Bestel tijdschrift (abonnement) - Kies tijdschrift, aantal en maanden
Toon alle bestellingen - Overzicht van alle orders
Afsluiten - Sluit het programma af

Belangrijke Features
1. Klasse-hiërarchie

Boek = basisklasse met ISBN, Naam, Uitgever, Prijs
Tijdschrift erft van Boek en voegt Verschijningsperiode toe

2. Prijsvalidatie

Prijs blijft altijd tussen €5 en €50
Lager → automatisch €5
Hoger → automatisch €50

3. Unieke Bestelling-ID's

Elke bestelling krijgt een oplopend volgnummer
Toegekend via een static counter

4. Tuple Return

Bestel() methode retourneert: (ISBN, Aantal, Totaalprijs)

5. Event System

Bij elke bestelling wordt een bevestigingsevent getriggerd
Toont: bestellingsnummer, productnaam en totaalprijs

6. Generieke Bestelling Klasse

Bestelling<T> werkt met zowel boeken als tijdschriften
Type constraint: where T : Boek

Testdata

Het systeem start met 5 boeken en 5 tijdschriften:

Boeken:

Clean Code (€35,99)
Design Patterns (€42,50)
Clean Architecture (€38,75)
Agile Software Development (€44,99)
Domain-Driven Design (€49,99)

Tijdschriften:

Tech Weekly - Wekelijks (€8,50)
Daily News - Dagelijks (€5,00)
Programming Monthly - Maandelijks (€12,99)
Science Today - Wekelijks (€15,50)
Business Magazine - Maandelijks (€18,75)
