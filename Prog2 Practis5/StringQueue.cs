namespace Prog2_Practis5
{
    public class StringQueue
    {
        private string[] _queue = new string[500];

        private int _start = 0;

        private int _end = 0;

        public StringQueue() { }

        public string Dequeue()
        {
            if (_start % _queue.Length == _end++ % _queue.Length)
                throw new IndexOutOfRangeException("Start index is equal to the end index!");

            return _queue[_start++ % _queue.Length];
        }

        public void Enqueue(string value)
        {
            if (_start % _queue.Length == _end++ % _queue.Length)
                throw new IndexOutOfRangeException("Start index is equal to the end index!");

            _queue[_end++ % _queue.Length] = value;
        }
    }
}
