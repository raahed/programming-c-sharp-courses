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

            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");

            Console.WriteLine("\n\nTesting Filter für Positive Zahlen...");

            MyFilter filterIfPositive = FilterIfPositive;

            Filter(list, filterIfPositive);

            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");


            Console.WriteLine("\n\nTesting Filter für teilbar durch zwei...");

            MyFilter filterIfModTwo = FilterIfModTwo;

            Filter(list, filterIfModTwo);

            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");

            Console.WriteLine("\n\nTesting MyDelegation class...");

            list.Add(-3);
            list.Add(-2);
            list.Add(-1);
            list.Add(1);
            list.Add(3);

            MyDelegation.MyFilter filters = MyDelegation.FilterIfModTwo;
            filters += MyDelegation.FilterIfPositive;

            MyDelegation.doFilter(list, filters);

            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");


            Console.WriteLine("\n\nTesting Operations...");

            MyOperation operationCollection = OperationAbsoluteValue;
            operationCollection += OperationMultiplyWithTwo;
            operationCollection += OperationAddOne;

            Console.Write("Values: ");
            foreach ( double d in doOperations(new double[] { -5, 2, -Math.PI }, operationCollection))
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
            for (int i = 0; i < list.Count; i++)
                if (filter(list[i]))
                    list.Remove(i);
        }
    }
}