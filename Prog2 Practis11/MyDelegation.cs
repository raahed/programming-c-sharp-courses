namespace Prog2_Practis11
{
    public class Filter
    {
        public delegate bool MyFilter(int item);

        public MyFilter filters;

        public Filter(MyFilter filters)
        {


            this.filters = filters;
        }

        public static bool FilterIfPositive(int item) => !(item > 0);

        public static bool FilterIfModTwo(int item) => !(item % 2 == 0);

        static void doFilter(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (filter(list[i]))
                    list.RemoveAt(i);
        }
    }
}
