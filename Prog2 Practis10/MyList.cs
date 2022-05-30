using System.Collections;

namespace Prog2_Practis10
{
    public class MyList<T> : List<T>, IEnumerable where T : IComparable
    {
        public T GetMaximum()
        {
            T max = this.First();

            foreach(T item in this)
                if(item.CompareTo(max) > 0)
                    max = item;

            return max;
        }
    }
}
