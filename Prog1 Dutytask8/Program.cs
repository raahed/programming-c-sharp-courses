using System;
using System.IO;

namespace Task8
{
    class Program
    {
        /// <summary>
        /// Auswertung der aktuellen Inzidenz aus einer Textdatei
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //relativer Pfad + Dateiname zur Basisdatei
            const string file = @"..\..\..\inzidenz.txt";

            //Deklarieren des Array fur die Bundesländer und für die Inzidenztabelle
            //gleichzeitig werden in der Methode LoadAndParseFile die Arrays befüllt
            LoadAndParseFile(file, out string[] states, out double[,] table);

            //Loop solange Analysen getätigt werden sollen
            while (true)
            {
                //Abfrage und Prüfung für das Länderkürzel
                Console.Write("Welches Bundesland soll ausgewertet werden? ");
                string state = Console.ReadLine().ToUpper();
                int stateIndex = ConvertStateToIndex(states, state);

                if (stateIndex == -1)
                {
                    Console.WriteLine("Das eingegebene Kürzel konnte nicht zugeordnet werden.");
                    continue;
                }

                Console.Clear();
                Console.WriteLine($"Diagramm für {state}");
                Console.WriteLine("=======================\n");

                //Abfrage und Prüfung für VON
                Console.Write($"Von Woche ( 1-{table.GetLength(0)}): ");
                int from = Convert.ToInt32(Console.ReadLine());

                if (from < 1 || from > table.GetLength(0) - 1)
                {
                    Console.WriteLine("Der Wert liegt außerhalb des Bereiches.");
                    continue;
                }

                //Abfrage und Prüfung für BIS
                Console.Write($"Bis Woche ({from}-{table.GetLength(0)}): ");
                int to = Convert.ToInt32(Console.ReadLine());

                if (to < from || to > table.GetLength(0))
                {
                    Console.WriteLine("Der Wert liegt außerhalb des Bereiches.");
                    continue;
                }

                //Ausgabe aller Wochen 'from' bis 'to'
                for (int i = from; i <= to; i++) PrintAnalyticsLine(table, i, stateIndex);

                //Abfrage, ob die Auswertung fortgesetzt werden soll
                Console.WriteLine();
                Console.Write("Weitere Analysen? (Y/N) ");
                char key = Console.ReadKey().KeyChar;

                if (key != 'y' && key != 'Y') break;

                Console.Clear();
            }
        }

        /// <summary>
        /// Ließt eine Textdatei ein und gibt zwei Arrays zurück
        /// </summary>
        /// <param name="file">Textdatei mit den aktuellen Inzidenzen</param>
        /// <param name="states">out: Rückgabe eines Arrays mit den Bundenländern</param>
        /// <param name="table">out: Rückgabe der akutellen Inzidenzen, 1D sind die Wochen - 1; 2D sind die Bundesländer</param>
        static void LoadAndParseFile(string file, out string[] states, out double[,] table)
        {
            states = null; table = null;

            StreamReader sr = new StreamReader(file);

            //Aufspalten der ersten Zeile nach '\t'
            string[] headElements = sr.ReadLine().Split('\t');

            table = new double[Convert.ToInt32(headElements[0]), headElements.Length - 1];

            //Schreiben der Länderkürzel in einen seperaten Array
            states = new string[headElements.Length - 1];
            for (int i = 0; i < headElements.Length - 1; i++) states[i] = headElements[i + 1];

            //Jede Zeile der Datei durchgehen
            for (int i = 0; !sr.EndOfStream; i++)
            {
                //Aufspalten der Zeile nach '\t'
                string[] elements = sr.ReadLine().Split('\t');

                //Einfügen Werte in 'table' beginnent bei 1, da 0 die Wochenangabe ist
                for (int j = 1; j < elements.Length; j++)
                {
                    table[i, j - 1] = Convert.ToDouble(elements[j]);
                }
            }
        }

        /// <summary>
        /// Methode zum ausgeben der einer Zeile der Analyse
        /// für ein bestimmtes Bundesland und eine bestimmte Woche
        /// </summary>
        /// <param name="table">2d Array mit den Inzidenzen</param>
        /// <param name="week">Die auszugebende Woche (Wert im Array -1)</param>
        /// <param name="stateIndex">Der Index des Länderkürzels</param>
        static void PrintAnalyticsLine(double[,] table, int week, int stateIndex)
        {
            //Auswerten der Inzidenz
            double value = table[week - 1, stateIndex];

            //Berechnen des Balken
            int width = (int)value / 10;

            Console.Write($"Woche {week,2}: {value,6} ");

            //Auswerten der Inzidenz zum bestimmen der Farbe
            if (value < 50) Console.ForegroundColor = ConsoleColor.Green;
            if (value > 50 && value < 100) Console.ForegroundColor = ConsoleColor.Yellow;
            if (value > 100) Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"{new String('\u2584', width)}\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Überprüft ob das Länderkürzel 'state' in 'states' vorhanden ist und
        /// gibt den Index, bzw. wenn nicht vorhanden -1, zurück 
        /// </summary>
        /// <param name="states">Array mit den Länderkürzeln</param>
        /// <param name="state">String mit dem Länderkürzel</param>
        /// <returns>Index des Länderkürzels</returns>
        static int ConvertStateToIndex(string[] states, string state)
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] == state) return i;
            }

            return -1;
        }
    }
}
