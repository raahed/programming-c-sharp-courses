using System.Diagnostics;

namespace study_prog2_practis_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing Time Class
            Console.WriteLine("Testing Time Class..");

            Time t1 = new Time(0, 1, 34, 56);
            Time t2 = new Time(1, 34, 5, 6);
            Time t3 = new Time(100, 23, 45, 67);

            Console.WriteLine(t1++);
            Console.WriteLine(++t1);
            Console.WriteLine(t1 - t2);
            Console.WriteLine(t2 + t3);

            // Testing Vektor Class
            Console.WriteLine("\n\nTesting Vektor Class..");

            Vektor v1 = new Vektor(1, 2, 1);
            Vektor v2 = new Vektor(2, 4, 1);

            Console.WriteLine(Vektor.CrossProduct(v1, v2));
            Console.WriteLine(v1 + v2);
            Console.WriteLine(Vektor.Dist(v1));

            // Play Console Game
            Console.WriteLine("\n\nPlay Console Game..");
            Console.WriteLine("Geben Sie einen Satz zum spielen ein..");
            PlayGame(Console.ReadLine());
        }

        static void PlayGame(string text)
        {
            ValueQueue queue = new ValueQueue((uint)text.Length);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            Console.WriteLine("Das Spiel startet in 3 Sekunden..");
            Thread.Sleep(1000);

            Console.WriteLine("Das Spiel startet in 2 Sekunden..");
            Thread.Sleep(1000);

            Console.WriteLine("Das Spiel startet in 1 Sekunde..");
            Thread.Sleep(1000);

            Console.Write("Text eingeben: ");

            bool firstTime = true;

            string typedText = "";

            ConsoleKey key;

            while ((key = Console.ReadKey().Key) != ConsoleKey.Enter && !queue.Full)
            {
                typedText += key.ToString();

                if (firstTime)
                {
                    firstTime = false;
                }
                else
                {
                    queue.Add(stopWatch.ElapsedMilliseconds);
                }

                stopWatch.Restart();
            }

            Console.WriteLine();

            if (typedText != text.ToUpper() || queue.Count + 1 < text.Length)
            {
                Console.WriteLine($"Leider hast du dich vertippt: {typedText}");
                return;
            }

            Console.WriteLine($"Dein Score: {queue.Average()} Punkte");
        }
    }
}