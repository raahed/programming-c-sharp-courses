﻿namespace Prog2_Practis10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Maximum...");

            string[] s = { "Auto", "Zeppelin", "Baum" };
            int[] i = { -1, 3, 0, 2 };
            double[] d = { 3.24, Math.PI, Math.E, 10 };

            Console.WriteLine($" Maximum für den Typ {s.GetType().Name} ist {GetMaximum<string>(s)}");
            Console.WriteLine($" Maximum für den Typ {i.GetType().Name} ist {GetMaximum<int>(i)}");
            Console.WriteLine($" Maximum für den Typ {d.GetType().Name} ist {GetMaximum<double>(d)}");

            try 
            {
               GetMaximum<int>(10); 
            } 
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
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

        static T GetMaximum<T>(object? obj) where T : IComparable<T>
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (!obj.GetType().IsArray)
                throw new ArgumentException("Argument must be type of array");

            T[] asArray = (T[])obj;

            T max = asArray[0];

            for (int i = 0; i < asArray.Length; i++)
                if (asArray[i].CompareTo(max) > 0)
                    max = asArray[i];

            return max;
        }
    }
}
