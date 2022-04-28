namespace study_prog2_practis_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Cases...");

            Time[] cases = new Time[24];

            Random rand = new Random();

            for (int i = 0; i < cases.Length; i++)
                cases[i] = new Time(rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000), rand.Next(0, 1000));

            Console.WriteLine("\nShow Cases...");

            for (int i = 0; i < cases.Length; i++)
                Console.WriteLine($"[{i + 1:d2}] {cases[i]}");

            Console.WriteLine("\nTesting Cases...");

            for (var i = 0; i < 6; i++)
                Console.WriteLine($"[{i + 1:d2}] Test with '+': {cases[i] + cases[i + 1]}");

            for (var i = 6; i < 12; i++)
                Console.WriteLine($"[{i + 1:d2}] Test with '-': {cases[i] - cases[i + 1]}");

            for (var i = 12; i < 18; i++)
                Console.WriteLine($"[{i + 1:d2}] Test with '*': {cases[i] * cases[i + 1]}");

            Console.WriteLine("\nTestable Cases...");

            Console.WriteLine($"[Test] {new Time(100, 100, 100, 100)}");
            Console.WriteLine($"[Test] {new Time(100, 100, 100, 100) * 2}");
        }
    }
}