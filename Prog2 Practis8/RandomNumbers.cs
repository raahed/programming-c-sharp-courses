using System.Collections;

namespace Prog2_Practis8
{
    public class RandomNumbers : IEnumerable, IEnumerator
    {
        private Random random = new Random();

        private int count;

        public RandomNumbers(int count)
        {
            this.count = count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return random;
        }

    }
}
