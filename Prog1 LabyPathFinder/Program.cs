using System;
using System.Threading;

class Program
{
    // Such-Funktion - die eigentliche Aufgabe.
    // Sucht rekursiv ausgehend von Zeile x und Spalte y nach dem Ausgang.
    // Gibt true zurück, wenn der Ausgang gefunden wurde, false bei einer Sackgasse.
    // Sollte bei jedem neuen Schritt die Ausgabe() aufrufen, damit man etwas sieht.

    /// <summary>
    /// Sucht das Ziel 'Z' in einem Labyrinth von links nach rechts.
    /// Angefangen bei dem Symbol 'S'.
    /// </summary>
    /// <param name="laby">2D-Array mit dem Labyrinth</param>
    /// <param name="x">Position im Labyrinth: Zeile</param>
    /// <param name="y">Position im Labyrinth: Spalte</param>
    /// <returns>true, wenn das Ziel gefunden wurde. false, Wenn es keinen Weg gibt.</returns>
    static bool Suche(char[,] laby, int x, int y)
    {
        // Suche in alle Himmelsrichtungen; Angefangen mit Osten
        int[,] map = { { x, y + 1 }, { x + 1, y }, { x - 1, y }, { x, y - 1 } };

        // Variablen zu dem Labyrinth
        char path = ' ', way = '\u006F', impasse = '\u00D7', start = 'S', goal = 'Z';

        // Bedingung, ob wir am Start sind
        if (laby[x, y] == start)
            return Suche(laby, x, y + 1);

        // Bedingung, ob wir am Ziel angekommen sind
        if (laby[x, y] == goal)
            return true;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            // Suchen nach dem Weg oder dem Ziel
            if (laby[map[i, 0], map[i, 1]] == path ||
                laby[map[i, 0], map[i, 1]] == goal)
            {
                // Ersetzen durch überprüften Pfad
                laby[x, y] = way;

                Ausgabe(laby);

                return Suche(laby, map[i, 0], map[i, 1]);
            }
        }

        // Wurde kein Weg oder das Ziel gefunden
        // wird der Weg zurück gegangen, bis wieder
        // ein unerforschter Weg kommt
        for (int i = 0; i < map.GetLength(0); i++)
        {
            // Der Weg wird zurückgelaufen
            if (laby[map[i, 0], map[i, 1]] == way)
            {
                // Ersetzen durch Sackgasse
                laby[x, y] = impasse;

                return Suche(laby, map[i, 0], map[i, 1]);
            }
        }

        // Ist kein Weg mehr möglich und
        // kein Ziel in der Nähe, gib
        // false zurück.
        return false;
    }
    // Gibt das Labyrinth auf der Console aus
    static void Ausgabe(char[,] laby)
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < laby.GetLength(0); i++)
        {
            for (int j = 0; j < laby.GetLength(1); j++)
                Console.Write(laby[i, j]);
            Console.WriteLine();
        }
        // Verzögere die Ausgabe, damit man bei der Suche etwas sieht
        Thread.Sleep(100);
    }

    static void Main()
    {
        // Labyrinth als string[] definieren und dann in char[,] konvertieren
        string[] labyString = {
                "#############################################################################",
                "S                     #   #   #         #       #   #           #           #",
                "# ##### ### ######### ### # # # ##### # # ##### # # # ##### # # ##### ##### #",
                "# #   # #   #     # #     # #   #     # # #   # # #   #   # # #       #   # #",
                "### # ### ### # # # ##### # ##### ##### # # ### # ##### # # # ######### ### #",
                "#   #     # # # #       # #   # # #   # # #     #   #   # # # #     #       #",
                "# ######### # # ##### ### ### # # # ### # # ######### ### ### # ### # #######",
                "# #         # # #     #     # # # #     # # #         # # #   # #   #     # #",
                "# ### ##### # # ####### ##### # # # ##### # ### # ##### # # ##### # ##### # #",
                "#   # #     # #     #     #   # # #     # #   # #     #   #   #   # #     # #",
                "### # # ### # ##### # ##### ### # ### ### ### # ##### # ##### # ##### ##### #",
                "#   # # #   #   # # # # #   #   #   # # #   # #     # # #   # #       # #   #",
                "# ##### ####### # # # # # ### # ### ### ### # ####### # # # # ### ##### # # #",
                "# #   #           #     # #   # # #   #     #   #     #   # #   #     # # # #",
                "# # # ################# # # ### # ### ######### # ######### ### ##### # # # #",
                "# # # #               # #   # #   #     #       # #   #   # #   # #   #   # #",
                "# # # # ############# ####### ### # ##### ####### # # # # # # ### # ####### #",
                "# # #   #     #     # #         # # #   # #   #     # # # # # #   #       # #",
                "# # ##### ### # ### # # # ####### # # # # # # ####### # # # # # ######### # #",
                "#         #     #   #   #         #   #     #         # #     #             Z",
                "#############################################################################"
                };

        char[,] laby = new char[labyString.Length, labyString[0].Length];
        for (int i = 0; i < laby.GetLength(0); i++)
            for (int j = 0; j < laby.GetLength(1); j++)
            {
                laby[i, j] = labyString[i][j];
                if (laby[i, j] == '#')
                    laby[i, j] = '\u2588'; // Sieht schöner aus als #
            }

        Ausgabe(laby);

        // Beginne bei Start-Zelle mit dem 'S' in Zeile 1, Spalte 0
        if (Suche(laby, 1, 0))
            Console.WriteLine("Gefunden!");
        else
            Console.WriteLine("Leider nicht gefunden!");
        Console.ReadKey();
    }
}