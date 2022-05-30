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

            MyFilter filterCollection = FilterIfPositive;

            Filter(list, filterCollection);

            Console.Write("List: ");

            foreach (int i in list)
                Console.Write($"{i} ");


            Console.WriteLine("\n\nTesting Filter für teilbar durch zwei...");

            filterCollection = FilterIfModTwo;

            Filter(list, filterCollection);

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

        delegate void MyOperation(ref double number);

        static void OperationAbsoluteValue(ref double number)
        {
            if (number < 0)
                number *= -1;
        }

        static void OperationMultiplyWithTwo(ref double number)
        {
            number *= 2;
        }

        static void OperationAddOne(ref double number)
        {
            number += 1;
        }

        static double[] doOperations(double[] numbers, MyOperation operations)
        {
            double[] values = numbers;

            for (int i = 0; i < values.Length; i++)
                operations(ref values[i]);

            return values;
        }

        delegate bool MyFilter(int item);

        static bool FilterIfPositive(int item) => !(item > 0);

        static bool FilterIfModTwo(int item) => !(item % 2 == 0);

        static void Filter(List<int> list, MyFilter filter)
        {
            for (int i = 0; i < list.Count; i++)
                if (filter(list[i]))
                    list.RemoveAt(i);
        }
    }
}