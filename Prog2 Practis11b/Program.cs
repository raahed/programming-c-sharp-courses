using System;
using System.IO;    // Required for the FileSystemWatcher class

namespace Prog2_Pracits11b
{
    class Program
    {
        static void MyRenameEvent(object sender, RenamedEventArgs args) // Event handler based on .NET delegate "RenameEventHandler" (See .NET documentation for more)
        {
            Console.WriteLine(args.OldName + " was renamed to " + args.Name);
        }

        static void MyRemoveEvent(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine(args.Name + " was deleted");
        }

        static void MyCreatedEvent(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine(args.Name + " was created");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Printing f(x)=? ...");

            // Set params
            (int start, int end, int scale) def = (-3, 3, 1);

            // Print f(x)=x
            PrintAsTable(def.start, def.end, def.scale,
                (int x) => x
            );

            PrintAsTextGraphic(def.start, def.end, def.scale,
                (int x) => x
            );

            // Print f(x)=1/2x²+1
            PrintAsTable(def.start, def.end, def.scale,
                (int x) => (double)(x * x) / 2 + 1
            );

            PrintAsTextGraphic(def.start, def.end, def.scale,
                (int x) => (double)(x * x) / 2 + 1
            );

            // Print f(x)=sin(x)
            PrintAsTable(def.start, def.end, def.scale,
                (int x) => Math.Sin(x)
            );

            PrintAsTextGraphic(def.start, def.end, def.scale,
                (int x) => Math.Sin(x)
            );

            // Funktion des Programmes (ohne Erweiterung b):
            // Das Programm überwacht den Pfad in watcher.Path
            // auf das Event watcher.Renamed von Dateien/Ordnern
            // im Pfad. Über watcher.NotifyFilter wird eingestellt,
            // auf welche Attribute reagiert werden soll.

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = Directory.GetCurrentDirectory(); // Directory for the watcher

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;    // Type of notfications (See NotifyFilters in .NET documentation for more)

            watcher.Filter = "";    // Filter for the watcher (Empty string = Watch all)

            watcher.Renamed += MyRenameEvent;   // Register own event handlers

            watcher.Deleted += MyRemoveEvent;   // Register own event handlers

            watcher.Created += MyCreatedEvent;  // Register own event handlers

            watcher.EnableRaisingEvents = true; // Start watching

            Console.WriteLine("Starting watcher in directory \"" + watcher.Path + "\"");

            Console.WriteLine("Please press a key to quit...");

            Console.ReadKey(true);
        }

        delegate double Function(int x);

        static void PrintAsTable(int start, int end, int scale, Function function)
        {
            if (end < start)
                throw new ArgumentException();

            if (scale < 0 || scale > (end - start))
                throw new ArgumentException();

            Console.WriteLine($"{"x",3} | {"f(x)",5} ");
            Console.WriteLine("---------");

            for (int i = start; i <= end; i += scale)
                Console.WriteLine($"{i,3} | {function(i),5:f2}");

            Console.WriteLine();
        }


        static void PrintAsTextGraphic(int start, int end, int scale, Function function)
        {
            if (end < start)
                throw new ArgumentException();

            if (scale < 0 || scale > (end - start))
                throw new ArgumentException();

            // Compute the smalles and the highest values
            (int top, int bottom) range = (0, 0);

            for (int i = start; i <= end; i += scale)
            {
                int value = (int)Math.Round(function(i));

                if (value < range.bottom)
                    range.bottom = value;

                if (value > range.top)
                    range.top = value;
            }

            // Print graph each line
            for (int y = range.top + 2; y >= range.bottom - 2; y--)
            {
                // Shift the graph
                Console.Write(' ');

                // Print cols
                for (int x = start - 1; x <= end + 1; x += scale)
                {

                    // If in range, use another color
                    if (y <= range.top && y >= range.bottom && x >= start && x <= end)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Get value
                    int value = (int)Math.Round(function(x));

                    // Print desc x
                    if (x == start - 1 && y == 0)
                        Console.Write("x -");

                    // Print desc f(x)
                    else if (y == range.top + 2 && x == 0)
                        Console.Write(" y ");

                    // Print value
                    else if (y == value)
                        Console.Write($"{(y == 0 ? '-' : ' ')}{'\u00b7'}{(y == 0 ? '-' : ' ')}");

                    // Print center
                    else if (y == 0 && x == 0)
                        Console.Write("-+-");

                    // Print vertical line
                    else if (x == 0)
                        Console.Write($"{(y == 0 ? '-' : ' ')}|{(y == 0 ? '-' : ' ')}");

                    // Print horizonal line
                    else if (y == 0)
                        Console.Write("---");

                    // Print spaces
                    else
                        Console.Write("   ");
                }

                Console.Write('\n');
                
            }

            Console.Write(" Green is in range.\n\n");

            Console.ResetColor();
        }
    }
}
