using System.Collections;

namespace Prog2_Dutytask3
{
    public class MyList<T> : IMyList<T>, IEnumerable where T : Vehicle
    {
        private Element<T> _first = null;

        public int Length
        {
            get
            {
                int counter = 0;

                Element<T> element = _first;

                for (; element != null; counter++)
                    element = element.next;

                return counter;
            }
        }

        public void Add(T newElement)
        {
            Element<T> newElementInstance = new Element<T>(newElement);

            // TODO Insert logic

            Element<T> last = GetLastElement();

            if (last == null)
                _first = newElementInstance;
            else
                last.next = newElementInstance;
        }

        public int Remove(Color color)
        {
            int counter = 0;

            Element<T> element = _first;

            while (element != null)
            {
                if (element.GetObj().VehicleColor == color)
                {
                    RemoveElement(element);
                    counter++;
                }

                element = element.next;
            }

            if (counter == 0)
                throw new ColorNotFoundException();

            return counter;
        }

        private void InsertAfter(Element<T> element, Element<T> newElement)
        {
            newElement.next = element.next;
            element.next = newElement;
        }

        private void InsertBefore(Element<T> element, Element<T> newElement)
        {
            Element<T> prev = FindPrevious(element);

            prev.next = newElement;
            newElement.next = element;
        }

        private Element<T> GetLastElement()
        {
            Element<T> element = _first;

            while(element != null)
                element = element.next;

            return element;
        }

        private void RemoveElement(Element<T> element)
        {
            Element<T> prev = FindPrevious(element);

            prev.next = element.next;
        }

        private Element<T> FindPrevious(Element<T> element)
        {
            Element<T> prev = _first;

            while (prev.next != element)
            {
                prev = prev.next;

                if (prev == null)
                    return null;
            }

            return prev;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyListEnum<T>(_first, Length);
        }
    }
}
