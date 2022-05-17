namespace Prog2_Dutytask3
{
    public class MyList<T> : IMyList<T>, IEnumerable<T> where T : Vehicle
    {
        private Element<T> _first = null;

        public Element<T> First
        {
            get { return _first; }
        }

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

            Element<T> element = _first;

            while (element != null)
            {
                /*
                 * 
                 * TODO
                 * 
                 */

                // Case 1: is before
                if (element.GetObj().RegistrationDate.CompareTo(newElement.RegistrationDate) < 0)
                {
                    InsertBefore(element, newElement);
                    break;
                }
                // Case 2: is after
                else if (element.GetObj().RegistrationDate.CompareTo(newElement.RegistrationDate) > 0)
                {
                    InsertAfter(element, newElement);
                    break;
                }
                // Case 3: look ahead, is equal
                else
                {
                    // Look in the future
                    if (element.next != null && element.next.GetObj().RegistrationDate.CompareTo(newElement.RegistrationDate) != 0)
                    {
                        InsertAfter(element, newElement);
                        break;
                    }
                }

                // Increment
                element = element.next;
            }

            if (element == null)
                _first = newElement;
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

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }
    }
}
