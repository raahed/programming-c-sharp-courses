using System.Collections;

namespace Prog2_Practis8
{
    public class RandomNumbersWithoutYield : IEnumerable
    {
        public class NumberEnum : IEnumerator
        {
            private int[] _numbers;

            private int _index = 0;

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public int Current
            {
                get { return _numbers[_index]; }
            }

            public NumberEnum(int[] numbers)
            {
                _numbers = numbers;
            }

            public bool MoveNext()
            {
                _index++;
                return (_index < _numbers.Length);
            }

            public void Reset()
            {
                _index = 0;
            }
        }

        Random rand = new Random();

        private int[] _numbers;

        public RandomNumbersWithoutYield(int count)
        {
            _numbers = new int[count];

            for(int i = 0; i < count; i++)
                _numbers[i] = rand.Next();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NumberEnum(_numbers);
        }

    }
}
