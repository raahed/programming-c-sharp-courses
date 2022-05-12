using System.Collections;

namespace Prog2_Practis8
{
    public class RandomNumbersWithYield : IEnumerable
    {
        Random rand = new Random();

        private int _limit;

        public RandomNumbersWithYield(int limit)
        {
            _limit = limit;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for(int i = 0; i < _limit; i++)
                yield return rand.Next();
        }

    }
}
