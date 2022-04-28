using System;

namespace Task7
{
    class Program
    {
        /// <summary>
        /// Türme von Hanoi
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.WriteLine("||| Türme von Hanoi |||\n");

            Console.Write("Anzahl der Scheiben (zwischen 1 und 7 eingeben): ");
            int scheiben = Convert.ToInt32(Console.ReadLine());

            //Wirft eine Exception, wenn der Wert ausserhalb liegt
            if (scheiben < 1 || scheiben > 7)
            {
                throw new ArgumentException("Der Wert muss zwischen 1 und 7 liegen!");
            }
            
            //Kopfzeile ausgeben
            Console.WriteLine($"\n{"[A]",-7} {"[B]",-7} {"[C]",-7}");

            string[] tuerme = Anfangszustand(scheiben);

            Ausgabe(tuerme);

            //Initialer Aufruf um den Turm von A nach C zu bringen
            int zuege = BewegeScheibe(tuerme, scheiben, 1, 2, 3);

            Console.WriteLine($"\nMindestens {zuege} Züge sind erforderlich.");
        }

        /// <summary>
        /// Funktion um einen initalen Zustand der Türme
        /// zu erstellen
        /// </summary>
        /// <param name="n">Anzahl der Scheiben für Turm A</param>
        /// <returns>Array aus Strings, die Türme</returns>
        static string[] Anfangszustand(int n)
        {
            string[] tuerme = new string[3];

            //Füllt den Turm A auf bis n
            for (int i = n; i > 0; i--) tuerme[0] += i;

            return tuerme;
        }

        /// <summary>
        /// Ausgabe der Türme
        /// </summary>
        /// <param name="tuerme">Array mit den Türmen</param>
        static void Ausgabe(string[] tuerme)
        {
            //Ausgaben linksbündig je Turm
            Console.WriteLine($"{tuerme[0],-7} {tuerme[1],-7} {tuerme[2],-7}");
        }

        /// <summary>
        /// Verschiebt eine Scheibe auf einen anderen Turm
        /// </summary>
        /// <param name="tuerme">Array mit den Türmen</param>
        /// <param name="von">Ausgangsturm: A=1, B=2, C=3</param>
        /// <param name="nach">Zielturm: A=1, B=2, C=3</param>
        /// <returns>Anzahl der Züge, immer 1</returns>
        static int VerschiebeScheibe(string[] tuerme, int von, int nach)
        {
            //Füge die Scheieb dem Zielturm hinzu
            tuerme[nach - 1] += tuerme[von - 1][^1];

            //Löscht die Scheibe vom Ausgangsturm
            tuerme[von - 1] = tuerme[von - 1].Remove(tuerme[von - 1].Length - 1);
            
            //Ausgabe nach jedem verschieben
            Ausgabe(tuerme);

            return 1;
        }

        /// <summary>
        /// Bewegt die Scheiben von 'von' nach 'nach' mit 
        /// verwendung des Zwischenspeichers 'ueber'
        /// </summary>
        /// <param name="tuerme">Array mit den Türmen</param>
        /// <param name="n">Anzahl der Scheiben, die zu verschieben sind</param>
        /// <param name="von">Ausgangsturm: A=1, B=2, C=3</param>
        /// <param name="ueber">Zwischenspeicher: A=1, B=2, C=3</param>
        /// <param name="nach">Zielturm: A=1, B=2, C=3</param>
        /// <returns>Anzahl der verwendeten Züge</returns>
        static int BewegeScheibe(string[] tuerme, int n, int von, int ueber, int nach)
        {
            //Zähler füpr die Summe der Züge
            int summe = 0;

            //Basisfall der Rekursion, wenn nur eine Scheibe zu verschieben ist
            if (n == 1) return VerschiebeScheibe(tuerme, von, nach);

            //Verschieben in den Zwischenspeicher
            summe += BewegeScheibe(tuerme, n - 1, von, nach, ueber);

            //Verschieben ausführen
            summe += VerschiebeScheibe(tuerme, von, nach);

            //Rekursiver Aufruf, verschieben aus dem Zwischenspeicher
            return summe + BewegeScheibe(tuerme, n - 1, ueber, von, nach);

         
        }
    }
}
