using System.Collections;

namespace Prog2_Dutytask3
{
    public class MyList<T> : IMyList<T>, IEnumerable where T : Vehicle
    {
        /// <summary>
        /// Stores the single linked list
        /// </summary>
        private Element<T> _first = null;

        /// <summary>
        /// Returns the first element
        /// </summary>
        public Element<T> First
        {
            get { return _first; }
        }

        /// <summary>
        /// Append a new element to the list,
        /// sorted in descending order.
        /// </summary>
        /// <param name="newElement">New element to append</param>
        public void Add(T newElement)
        {
            if (newElement == null)
                throw new ArgumentNullException();

            Element<T> newElementInstance = new Element<T>(newElement);

            // When the list is empty, insert
            if (_first == null)
            {
                _first = newElementInstance;
                return;
            }

            Element<T> element = _first;

            // Save the date ;)
            DateTime newElementRegistrationDate = newElementInstance.GetObj().RegistrationDate;

            // Find the correct place
            while (element != null)
            {
                // If 'element' is smaller, insert before
                if (element.GetObj().RegistrationDate.CompareTo(newElementRegistrationDate) < 0)
                {
                    InsertBefore(element, newElementInstance);
                    return;                   
                }

                // Check if it is equal and the next is not equal
                else if (element.GetObj().RegistrationDate.CompareTo(newElementRegistrationDate) == 0 && element.next != null &&
                  element.next.GetObj().RegistrationDate.CompareTo(newElementRegistrationDate) != 0)
                {
                    InsertAfter(element, newElementInstance);
                    return;
                }

                // If next is null, insert
                if (element.next == null)
                {
                    InsertAfter(element, newElementInstance);
                    return;
                }

                element = element.next;
            }
        }

        /// <summary>
        /// Removes elements from the list,
        /// filtered by color
        /// </summary>
        /// <param name="color">Searched color</param>
        /// <returns>Returns the total amount of removed elements</returns>
        /// <exception cref="ColorNotFoundException">Thrown when, there is no element with the given color</exception>
        public int Remove(Color color)
        {
            int counter = 0;

            Element<T> element = _first;

            // Find any matching color
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

        /// <summary>
        /// Private function: Inserts after the given element
        /// </summary>
        /// <param name="element">Element from the single linked list</param>
        /// <param name="newElement">New element</param>
        private void InsertAfter(Element<T> element, Element<T> newElement)
        {
            element.next = newElement;
        }

        /// <summary>
        /// Private function: Inserts before the given element
        /// </summary>
        /// <param name="element">Element from the single linked list</param>
        /// <param name="newElement">New element</param>
        private void InsertBefore(Element<T> element, Element<T> newElement)
        {
            Element<T> prev = FindPrevious(element);

            if (prev == null)
            {
                _first = newElement;
                _first.next = element;

            }
            else
            {
                prev.next = newElement;
                newElement.next = element;
            }
        }

        /// <summary>
        /// Private function: Removes a element from the list
        /// </summary>
        /// <param name="element">Key element to remove</param>
        private void RemoveElement(Element<T> element)
        {
            Element<T> prev = FindPrevious(element);

            // If the element is the first 
            if (prev == null)
                _first = element.next;
            else
                prev.next = element.next;
        }

        /// <summary>
        /// Private function: finds the previous element
        /// </summary>
        /// <param name="element">element from the single linked list</param>
        /// <returns></returns>
        private Element<T> FindPrevious(Element<T> element)
        {
            Element<T> prev = _first;

            while (prev.next != element)
            {
                prev = prev.next;

                // Return null if the element is not in the list
                if (prev == null)
                    return null;
            }

            return prev;
        }

        /// <summary>
        /// Make the instance iterable
        /// </summary>
        /// <returns>A MyListEnum instance</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyListEnum<T>(this);
        }
    }
}
