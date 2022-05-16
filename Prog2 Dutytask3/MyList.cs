namespace Prog2_Dutytask3
{
    public class MyList<T> where T : Vehicle, IMyList<T>, IEnumerable<T>
    {
        private Element<Vehicle> _first = null;

        public int Length
        {
            get
            {
                int counter = 0;

                Element<Vehicle> element = _first;

                for (; element != null; counter++)
                    element = element.next;

                return counter;
            }
        }

        public void Add(Element<Vehicle> newElement)
        {
            Element<Vehicle> element = _first;

            while (element != null)
            {
                if (newElement.GetObj().RegistrationDate.CompareTo(element.GetObj().RegistrationDate) < 0)
                    break;

                // TODO
                element = element.next;
            }

            if (element == null)
                _first = newElement;
            else
                element.next = newElement;

            // TODO
        }

        public int Remove(Color color)
        {
            int counter = 0;

            Element<T> element = _first;

            while(element != null)
            {
                if(element.GetObj().VehicleColor == color)
                {
                    RemoveElement(element);
                    counter++;
                }

                element = element.next;
            }

            return counter;
        }

        private static void InsertAfter(Element<T> element, Element<T> newElement)
        {
            newElement.next = element.next;
            element.next = newElement;
        }

        private static void RemoveElement(Element<T> element)
        {
            Element<T> prev = FindPrevious(element);

            prev.next = element.next;
        }

        private static Element<Vehicle> FindPrevious(Element<Vehicle> element)
        {
            Element<Vehicle> prev = _first;

            while(prev.next != element)
                prev = prev.next;

            return prev;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)new MyListEnum<Vehicle>(_first, Length);
        }
    }
}
