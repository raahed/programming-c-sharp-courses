using System.Collections;

namespace Prog2_Dutytask3
{
    public class MyListEnum<T> : IEnumerator where T : Vehicle
    {
        private Element<T> _list;

        private int _position = -1;

        private int _length;

        public MyListEnum(Element<T> list, int length)
        {
            _list = list;
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

         string Current
        {
            get
            {
                Element<T> element = _list;

                for (int i = 0; i < _position; i++)
                    element = element.next;

                if (element == null || _position < 0)
                    throw new InvalidOperationException();

                return element.GetObj().GetInfo();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}
