namespace Prog2_Practis9
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Read length
            int length = 0;
            while (true)
            {
                Console.Write("Länge des Arrays eingeben: ");

                handleInput(out length);

                if (length < 1)
                {
                    Console.WriteLine("Länge muss mindestens 1 sein.");
                }
                else
                {
                    break;
                }
            }

            // Create Array
            int[] arr = new int[length];


            // Read data
            int i = 0;
            while (true)
            {
                Console.Write($"[{i + 1}] Daten eingeben: ");

                bool status = handleInput(out int lastInput);

                if (lastInput == 0)
                    break;

                if (status)
                {
                    try
                    {
                        arr[i] = lastInput;
                    }
                    catch
                    {
                        Console.WriteLine($"Daten an der Stelle {i + 1} wurden nicht gespeichert.");
                        break;
                    }
                    finally
                    {
                        i++;
                    }
                }
            }

            // Read Prefix
            int prefix = 0;
            while (true)
            {
                Console.Write("Präfix eingeben: ");

                handleInput(out prefix);

                if (prefix > length)
                {
                    Console.WriteLine("Der Präfix ist zu lang.");
                }
                else
                {
                    break;
                }
            }

            // Testing prefix


            // Calc sqrt
            try
            {
                calcSqrt(arr, prefix);
            }
            catch (InvalidSqrtException ex)
            {
                Console.WriteLine($"Die Berechnung wurde mit einem negativen Wert ausgeführt: {ex.Message}");
            }


            // Print Array
            for (int j = 0; j < arr.Length; j++)
                Console.WriteLine($"[{j + 1:d3}] Wert: {arr[j],3}");
        }

        static bool handleInput(out int input)
        {
            try
            {
                input = int.Parse(Console.ReadLine());

                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Deine Eingabe hatte ein falsches Format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deine Eingabe ist fehlerhaft: {ex.Message}");
            }

            input = 0;
            return false;
        }

        static void calcSqrt(int[] array, int prefix)
        {
            int sum = 0;
            for (int i = 0; i < prefix; i++)
            {
                if (array[i] < 0)
                    throw new InvalidSqrtException();

                sum += array[i] * array[i];
            }

            double sqrt = Math.Sqrt(sum);

            array[prefix - 1] = (int)Math.Round(sqrt);
        }
    }
}