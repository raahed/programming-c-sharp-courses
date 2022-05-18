using System.Collections;

namespace Prog2_Dutytask3
{
    public class MyListEnum<T> : IEnumerator where T : Vehicle
    {
        /// <summary>
        /// Current list element
        /// </summary>
        private Element<T> _current = null;

        /// <summary>
        /// The single linked list instance
        /// </summary>
        private MyList<T> _list;


        public MyListEnum(MyList<T> list)
        {
            _list = list;
        }

        /// <summary>
        /// Move to the next element
        /// </summary>
        /// <returns>returns true when the move was possible</returns>
        public bool MoveNext()
        {
            if (_current == null)

                _current = _list.First;
            else
                _current = _current.next;

            return (_current != null);
        }

        /// <summary>
        /// Reset the iteration
        /// </summary>
        public void Reset()
        {
            _current = null;
        }

        /// <summary>
        /// Returns the information about the current given element
        /// </summary>
        string Current
        {
            get { return _current.GetObj().GetInfo(); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
