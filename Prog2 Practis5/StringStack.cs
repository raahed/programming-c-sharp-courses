namespace Prog2_Practis5
{
    public class StringStack
    {
        private string[] _stack = new string[500];

        private uint _pointer = 0;

        public StringStack() {}

        public string Pop()
        {
            return _stack[_pointer--];
        }

        public void Push(string value)
        {
            _stack[_pointer++] = value;
        }
    }
}
