using System;

namespace Task6
{
    class Program
    {
        /// <summary>
        /// Test method
        /// </summary>
        static void Main(string[] args)
        {
            int n = 6, m = 5;
            int[] rhyme = Abzaehlen(n, m);

            //Print rhyme
            for (int i = 0; i < n; i++)
            {
                //Print rhyme, with ','
                Console.Write($"{rhyme[i]}{(i == n - 1 ? "" : ", ")}");
            }
        }

        /// <summary>
        /// Counting rhyme for n kids with the rhyme m
        /// </summary>
        /// <param name="n">count of kids</param>
        /// <param name="m">rhyme scheme</param>
        /// <returns>array sequence of kicked kids</returns>
        static int[] Abzaehlen(int n, int m)
        {
            //default is false to avoid one more loop
            bool[] kids = new bool[n];
            
            //array to save each kicked kid position
            int[] kickedKids = new int[n];

            //position pointer for the current action
            int pointer = 0;

            //loop for each kids
            for (int i = 0; i < n; i++)
            {
                //first action, jump to next start
                //find start position if posiion is true, pointer++
                while (kids[pointer % n]) pointer++;

                //second action, jump to the next number
                //loop minimum m, but add all positions
                //where the kids already kicked out (true)
                int counter = 1;
                while (counter < m)
                {
                    pointer++;

                    //only count when the kid is false
                    if (!kids[pointer % n]) counter++;
                }

                //third action, set kid at pointer true
                //tell 'kickedKids' the position
                kids[pointer % n] = true;
                kickedKids[i] = (pointer % n) + 1; //+1 for display
            }

            return kickedKids;
        }
    }
}
