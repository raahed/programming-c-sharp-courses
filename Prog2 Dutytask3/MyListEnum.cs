namespace Prog2_Dutytask3
{
    public class MyListEnum<T> where T : Vehicle, IEnumerator<T>
    {
        private Element<T> _first;

        private int _position = -1;

        private int _length;

        public MyListEnum(Element<T> list, int length)
        {
            _first = list;
            _length = length;
        }

        public bool MoveNext()
        {
            return (++_position < _length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public Element<T> Current
        {
            get
            {
                Element<T> element = _first;

                for (int i = 0; i < _position; i++)
                    element = element.next;

                if (element == null || _position < 0)
                    throw new InvalidOperationException();

                return element;
            }
        }

    }
}
