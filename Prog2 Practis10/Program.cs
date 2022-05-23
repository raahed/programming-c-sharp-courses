namespace Prog2_Practis10
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testing Stack...");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            try
            {
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"One Operation was outside of boundary: {e.Message}");
            }


        }
    }
}