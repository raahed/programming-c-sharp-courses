using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_prog2_practis_2
{
    class CursorGame
    {
        private int pointer_left, pointer_top;

        public CursorGame()
        {
            setup();
        }

        private void setup()
        {
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.BackgroundColor = ConsoleColor.Gray;

            Console.Clear();

            pointer_left = pointer_top = 10;
        }

        public void play()
        {
            while (true)
            {
                char key;

                Console.SetCursorPosition(pointer_left, pointer_top);

                Console.Write("X");

                key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case 'a':
                        pointer_left -= 1;
                        break;

                    case 'd':
                        pointer_left += 1;
                        break;

                    case 'w':
                        pointer_top -= 1;
                        break;

                    case 's':
                        pointer_top += 1;
                        break;
                }
            }
        }
    }
}
