namespace Prog2_Dutytask3
{
    // Element ist eine generische Wrapper-Klasse, welche Vehicles kapseln
    // kann.
    // Verwenden Sie diese Klasse in ihrer Implementierung der verketteten
    // Liste.
    public class Element<T> where T : Vehicle
    {
        private T obj;
        public Element<T> next;

        public T GetObj()
        {
            return obj;
        }

        public Element(T obj)
        {
            this.obj = obj;
            this.next = null;
        }
    }
}
