using System.Collections;
using System.Collections.Generic;

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
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(-1);
            Console.WriteLine($"Maximum für List ist {GetMaximumFromStruct<int, List<int>>(list)}!");

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

        static T GetMaximum<T>(T[] array) where T : IComparable
        {
            T max = array[0];

            for (int i = 0; i < array.Length; i++)
                if (array[i].CompareTo(max) > 0)
                    max = array[i];

            return max;
        }

        static T1 GetMaximumFromStruct<T1, T2>(T2 obj) where T1 : IComparable where T2 : IEnumerable
        {
            T1 max = default(T1);

            foreach (T1 item in obj)
                if (item.CompareTo(max) > 0)
                    max = item;

            return max;
        }
    }
}
