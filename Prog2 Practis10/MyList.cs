using System.Collections;

namespace Prog2_Practis10
{
    public class MyList<T> : List<T>, IEnumerable where T : IComparable
    {
        public T GetMaximum()
        {
            T[] array = ToArray();

            T max = array[0];

            for(int i = 1; i < array.Length; i++)
                if(array[i].CompareTo(max) > 0)
                    max = array[i];

            return max;
        }
    }
}
