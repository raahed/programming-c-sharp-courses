namespace Prog2_Practis10
{
    public class Stack<T>
    {
        private class Element<T>
        {
            public Element<T> next = null;
            public Element<T> prev = null;
            public T value;

            public Element(T value)
            {
                this.value = value;
            }
        }

        Element<T> bottom = null;

        public Stack() { }

        public T Pop()
        {
            Element<T> element = bottom;

            if (element == null)
                throw new IndexOutOfRangeException("Empty Stack");

            while (element.next != null)
                element = element.next;

            if(element.prev != null)
            {
                element.prev.next = null;
                element.prev = null;
            } else
            {
                bottom = null;
            }

            return element.value;
        }
            
        public void Push(T value)
        {
            Element<T> newElement = new Element<T>(value);

            if (bottom == null)
            {
                bottom = newElement;
                return;
            }

            Element<T> element = bottom;

            while (element.next != null)
                element = element.next;

            element.next = newElement;
            newElement.prev = element;
        }
    }
}
