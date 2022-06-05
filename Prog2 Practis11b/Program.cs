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

		static void MyRemoveEvent(object sender,  FileSystemEventArgs args)
		{
			Console.WriteLine(args.Name + " was deleted");
		}

		static void MyCreatedEvent(object sender, FileSystemEventArgs args)
		{
			Console.WriteLine(args.Name + " was created");
		}

		static void Main(string[] args)
		{
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
	}
}
