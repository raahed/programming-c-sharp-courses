namespace Prog2_Practis11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(-3);
            list.Add(-2);
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            PrintList(list);

            Console.WriteLine("\n\nTesting Filter für Positive Zahlen...");

            MyFilter filterIfPositive = FilterIfPositive;

            Filter(list, filterIfPositive);

            PrintList(list);


            Console.WriteLine("\n\nTesting Filter für teilbar durch zwei...");

            MyFilter filterIfModTwo = FilterIfModTwo;

            Filter(list, filterIfModTwo);

            PrintList(list);

            Console.WriteLine("\n\nTesting MyDelegation class...");

            List<int> list2 = new List<int>();
            list2.Add(-3);
            list2.Add(-2);
            list2.Add(-1);
            list2.Add(0);
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);

            MyDelegation.MyFilter filterIfModTwo2 = MyDelegation.FilterIfModTwo;
            MyDelegation.doFilter(list2, filterIfModTwo2);

            MyDelegation.MyFilter filterIfPositive2 = MyDelegation.FilterIfPositive;
            MyDelegation.doFilter(list2, filterIfPositive2);

            PrintList(list2);


            Console.WriteLine("\n\nTesting Operations...");

            MyOperation operationCollection = OperationAbsoluteValue;
            operationCollection += OperationMultiplyWithTwo;
            operationCollection += OperationAddOne;

            double[] dArray = { -5, 2, -Math.PI };

            Console.Write("Values: ");
            foreach (double d in doOperations(dArray, operationCollection))
                Console.Write($"{d} ");

        }

        delegate void MyOperation(ref double x);

        static void OperationAbsoluteValue(ref double x)
        {
            if (x < 0)
                x *= -1;
        }

        static void OperationMultiplyWithTwo(ref double x)
        {
            x *= 2;
        }

        static void OperationAddOne(ref double x)
        {
            x += 1;
        }

        static double[] doOperations(double[] numbers, MyOperation operations)
        {
            for (int i = 0; i < numbers.Length; i++)
                operations(ref numbers[i]);

            return numbers;
        }

        delegate bool MyFilter(int item);

        static bool FilterIfPositive(int item) => (item < 0);

        static bool FilterIfModTwo(int item) => !(item % 2 == 0);

        static void Filter(List<int> list, MyFilter filter)
        {
            int counter = 0;

            while (counter < list.Count)
                if (filter(list[counter]))
                    list.RemoveAt(counter);
                else
                    counter++;
        }

        static void PrintList(List<int> list)
        {
            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");
        }
    }
}