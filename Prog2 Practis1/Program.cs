namespace Prog2_Practis1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 34, 56};

            Console.WriteLine($"Summe: {Sum(test)}");

            Console.WriteLine($"Durchschnitt: {Average(test)}");

            Console.WriteLine($"Ist das Array Monoton steigend? {(IsMonotonous(test) ? "Ja" : "Nein")}");

            Console.WriteLine(FieldAsBar(test));

            Console.WriteLine("_____");
        }

        static int Sum(int[] a)
        {
            int sum = 0;

            for (int i = 0; i < a.Length; i++)
                sum += a[i];

            return sum;
        }

        static int Average(int[] a)
        {
            return Sum(a) / a.Length;
        }

        static bool IsMonotonous(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
                if (a[i] <= a[i + 1])
                    return false;

            return true;
        }

        static string FieldAsBar(int[] a)
        {
            string bars = "";

            for(int i = 0; i < a.Length; i++)
            {
                bars += a[i] + ": ";
                for (int j = 0; j < a[i]; j++)
                    bars += "|";
                bars += "\n";

            }

            return bars;
        }
    }
}