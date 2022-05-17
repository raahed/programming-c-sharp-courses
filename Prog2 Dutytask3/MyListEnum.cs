namespace Prog2_Dutytask3
{
    public class MyListEnum<T> where T : Vehicle, IEnumerator<T>
    {
        private MyList<T> _list;

        private int _position = -1;

        public MyListEnum(MyList<T> list)
        {
            _list = list;
        }

        public bool MoveNext()
        {
            return (++_position < _list.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current
        {
            get
            {
                Element<T> element = _list.First;

                for (int i = 0; i < _position; i++)
                    element = element.next;

                if (element == null || _position < 0)
                    throw new InvalidOperationException();

                return element.GetObj();
            }
        }

    }
}
