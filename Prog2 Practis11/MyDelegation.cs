namespace Prog2_Practis11
{
    public class MyDelegation
    {
        public delegate void MyAfterFilter(List<int> list);

        public delegate bool MyFilter(int item);

        public static MyAfterFilter afterFilter;

        static MyDelegation()
        {
            afterFilter = AfterFilterAppendNull;
            afterFilter += AfterFilterDoubleValues;
        }

        public static bool FilterIfPositive(int item) => (item < 0);

        public static bool FilterIfModTwo(int item) => !(item % 2 == 0);

        public static void AfterFilterDoubleValues(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] += list[i];
        }

        public static void AfterFilterAppendNull(List<int> list)
        {
            list.Add(0);
        }

        public static void doFilter(List<int> list, MyFilter filter)
        {
            for (int i = 0; i < list.Count; i++)
            { 
                if (filter(list[i]))
                    list.RemoveAt(i);
                afterFilter(list);
            }

        }
    }
}
