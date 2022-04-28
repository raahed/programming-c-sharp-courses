using System;

namespace prog2_dutytask_1
{
    /// <summary>
    /// Potentialfeldmethode
    /// </summary>
    class Program
    {
        /// <summary>
        /// Aufruf der Karte und der Navigation mithilfe der
        /// Potentialfeldmethode.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Karte karte = new Karte(@"..\..\..\Spielfeld.txt");
            for (int i = 0; i < 10; i++)
            {
                if (karte[i] != null)
                {
                    Navigator navi = new Navigator(karte, i);
                    if (navi.WegZumZielSuchen())
                        Console.WriteLine("Das Ziel wurde erreicht");
                    else
                        Console.WriteLine("Ziel nicht erreicht!");
                }
            }
        }
    }
}