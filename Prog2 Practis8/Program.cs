namespace Prog2_Practis8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Fracture...");

            Fracture[] fractures = new Fracture[]
            {
                new Fracture(12,44),
                new Fracture(5,6),
                new Fracture(3,9),
                new Fracture(7,10),
                new Fracture(11,5),
                new Fracture(4,2),
                new Fracture()
            };

            Console.WriteLine("Unsorted:");
            foreach (Fracture fract in fractures)
                Console.WriteLine(fract);

            Array.Sort(fractures);

            Console.WriteLine("Sorted:");
            foreach (Fracture fract in fractures)
                Console.WriteLine(fract);
        }
    }
}