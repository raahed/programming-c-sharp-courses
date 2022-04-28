using System;

namespace Task5
{
    class Program
    {
        /// <summary>
        ///  Bereits vorgegebene Test-Methode
        /// </summary>
        static void Main(string[] args)
        {
            for (double d = -Math.PI; d < Math.PI; d += 0.3)
            {
                Console.WriteLine($"{Math.Sin(d),25} | {MySin(d),25} | {Math.Sin(d) - MySin(d),25}");
            }

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Wuerfeltest: längste Kette: {Wuerfeltest(100000)}");
            //Die Anzahl bei funktionierendem Programm erhöhen!

            Console.WriteLine("-------------------------------");
            int a = 5, b = 3;
            SortSwap(ref a, ref b);
            Console.WriteLine($"Sort-Swap: {a} - {b}");
            SortSwap(ref a, ref b);
            Console.WriteLine($"Sort-Swap: {a} - {b}");

            Console.WriteLine("-------------------------------");
            double g, f;
            DoubleSplit(3.14, out g, out f);
            Console.WriteLine($"Double-Split: {g}|{f}");            
        }

        /// <summary>
        /// Berechnet den Sinus von x mithilfe der Taylor Reihe für 18 Glieder
        /// https://de.wikipedia.org/wiki/Taylorreihe#Trigonometrische_Funktionen
        /// </summary>
        /// <param name="x">Wert der Kreisfunktion zwischen -PI und PI</param>
        /// <returns>Gibt den Wert von sin(x) zurück</returns>
        static double MySin(double x)
        { 
            //Speicher für die Summe
            double sum = 0;

            //n=0 bis n=17 berechnung der Tylor Reihe
            for (int n = 0; n < 18; n++)
            {
                //Berechnung jedes Gliedes in der Reihe
                sum += Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / Fak(2 * n + 1);
            }

            return sum;
        }

        /// <summary>
        /// Berechnet die Fakultät rekursiv für natürliche Zahlen
        /// Berechnung erfolgt mit double Werten, bei int & long
        /// kann es zu einem Überlauf kommen
        /// </summary>
        /// <param name="x">Eine natürliche Zahl</param>
        /// <returns>Gib die Fakultät für x zurück</returns>
        static double Fak(double x)
        {
            //Basisfall wenn x < 2 wird
            if (x < 2) return 1;

            return Fak(x - 1) * x;
        }

        /// <summary>
        /// Würfelt für die Anzahl 'anzahlVersuche' und ruft PaschAnzahl() auf.
        /// </summary>
        /// <param name="anzVersuche">Anzahl der Versuche, wie häufig gewürfelt werden soll</param>
        /// <returns>Gibt den Wert der längsten gewürfelten Pasch-Serie zurück</returns>
        static int Wuerfeltest(int anzVersuche)
        {
            Random rand = new Random();

            //Erster Wurf beginnt mit 3, meine Lieblingszahl :)
            int ersterWurf = 3;

            //Speicher für die längste Serie
            int längsteSerie = 0;

            for (int i = 0; i < anzVersuche; i++)
            {
                int aktuelleSerie = PaschAnzahl(rand, ref ersterWurf);

                //Wenn die aktuelle Serie länger ist, als die längste,
                //wird aktuelle Serie in längste Serie geschrieben
                if(aktuelleSerie > längsteSerie) längsteSerie = aktuelleSerie;
            }

            return längsteSerie;
        }

        /// <summary>
        /// Versucht eine möglichst lange Serie an gleichen Würfelergebnissen zu erziehen
        /// </summary>
        /// <param name="wuerfel">Instanz der Random-Klasse</param>
        /// <param name="ersterWurf">Referenz: Auf den ersten Wurf, 
        /// müssen die gewürfelten Zahlen folgen</param>
        /// <returns>Gibt die geschaffte länge des Pasches zurück</returns>
        static int PaschAnzahl(Random wuerfel, ref int ersterWurf)
        {
            //Länge der Serie
            int zähler = 0;

            //Würfelt solange, bis die Würfel ungleich werden
            while (true)
            {
                int versuch = wuerfel.Next(1, 7);

                if (versuch == ersterWurf)
                {
                    zähler++;
                }
                else
                {
                    ersterWurf = versuch;
                    break;
                }
            }

            return zähler;
        }

        /// <summary>
        /// Sortiert 'a' und 'b', sodass 'a' immer die kleinere Zahl ist. 
        /// Die Werte werden in die referenz Variablen geschrieben.
        /// 
        /// Verwendung von "ref", damit die Variablen und Werte aus
        /// dem Methodenaufruf überschrieben werden.
        /// </summary>
        /// <param name="a">Ganze Zahl</param>
        /// <param name="b">Ganze Zahl</param>
        static void SortSwap(ref int a, ref int b)
        {
            //Nur wenn a > b ist, müssen die Zahlen umsortiert werden
            if (a > b)
            {
                int speicher = a;
                a = b;
                b = speicher;
            }
        }

        /// <summary>
        /// Teilt die Zahl 'd' in die Vor- Nachkommastellen auf
        /// 
        /// Verwendung von "out". Damit werden die neu erzeugten
        /// Werte in die Variablen im Methodenaufruf geschrieben.
        /// </summary>
        /// <param name="d">Zuteilende Zahl</param>
        /// <param name="ganzZahl">Gibt eine ganze Zahl zurück</param>
        /// <param name="rest">Gibt den Rest zurück</param>
        static void DoubleSplit(double d, out double ganzZahl, out double rest)
        {
            ganzZahl = (int)d;
            rest = d - ganzZahl;
        }
    }
}
