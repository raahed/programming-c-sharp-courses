namespace Prog2_Practis10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Maximum...");

            string[] s = { "Auto", "Zeppelin", "Baum" };
            int[] i = { -1, 3, 0, 2 };
            double[] d = { 3.24, Math.PI, Math.E, 10 };

            Console.WriteLine($" Maximum für den Typ {s.GetType().Name} ist {GetMaximum(s)}");
            Console.WriteLine($" Maximum für den Typ {i.GetType().Name} ist {GetMaximum(i)}");
            Console.WriteLine($" Maximum für den Typ {d.GetType().Name} ist {GetMaximum(d)}");

            Console.WriteLine("Testing MyList maximum...");
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(-1);

            Console.WriteLine($"Maximum für MyList ist {list.GetMaximum()}!");

            Console.WriteLine("Testing Stack...");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            try
            {
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"One Operation was outside of boundary: {e.Message}");
            }
        }

        static T GetMaximum<T>(T[] array) where T : IComparable<T>
        {
            if (array == null)
                throw new ArgumentNullException();

            T max = array[0];

            for (int i = 1; i < array.Length; i++)
                if (array[i].CompareTo(max) > 0)
                    max = array[i];

            return max;
        }
    }
}