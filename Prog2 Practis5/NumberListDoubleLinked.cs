namespace Prog2_Practis5
{
    /*
     * Based on https://elearning.ohmportal.de/mod/resource/view.php?id=245199
     */
    class NumberListDoubleLinked
    {
        // Internal class:

        public class Element
        {
            public int Data;
            public Element Previous;    // New!
            public Element Next;

            public Element(int data, Element previous, Element next)
            {
                Data = data;
                Previous = previous;    // New!
                Next = next;
            }
        }

        // Data fields:

        Element first = null;
        Element last = null;

        // Read-only properties:

        public Element First
        {
            get { return first; }
        }

        public Element Last
        {
            get { return last; }
        }

        // Methods:

        public void Prepend(int data)
        {
            Element newElement = new Element(data, null, First);

            if (First == null)
            {
                last = newElement;
            }
            else
            {
                first.Previous = newElement;
            }

            first = newElement;
        }

        public Element InsertAfter(Element previous, int data)
        {
            if (previous == null)
            {
                throw new ArgumentNullException("Cannot insert after null element!");
            }

            Element newElement = new Element(data, previous, previous.Next);

            if (previous.Next == null)
            {
                last = newElement;
            }
            else
            {
                previous.Next.Previous = newElement;
            }

            previous.Next = newElement;

            return newElement;
        }

        public void Append(int data)
        {
            if (Last == null)
            {
                Prepend(data);
            }
            else
            {
                InsertAfter(Last, data);
            }
        }

        public Element Find(int data)
        {
            return Find(data, First);
        }

        public Element Find(int data, Element start)
        {
            if (start == null)
            {
                return null;
            }

            if (start.Data == data)
            {
                return start;
            }

            return Find(data, start.Next);
        }

        public Element Remove(Element element)  // Returns the next list element
        {
            if (element == null)
            {
                throw new ArgumentNullException("Cannot remove null element!");
            }

            if (element.Previous == null)
            {
                first = element.Next;
            }
            else
            {
                element.Previous.Next = element.Next;
            }

            if (element.Next == null)
            {
                last = element.Previous;
            }
            else
            {
                element.Next.Previous = element.Previous;
            }

            return element.Next;
        }

        public void RemoveAll()
        {
            first = null;
            last = null;
        }

        public uint Count()
        {
            uint count = 0;

            Element element = First;

            while (element != null)
            {
                count++;

                element = element.Next;
            }

            return count;
        }

        public void Sort()
        {

        }

        public void Reverse()
        {

        }
    }

}
