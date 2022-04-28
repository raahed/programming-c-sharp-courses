using System;
using System.IO;


namespace übung8
{
    class Program
    {
        static void Main(string[] args)
        {
            const string salesFile = "verkauf.txt";
            const string ebitFile = "umsatz.txt";

            Console.WriteLine($"Aktuelles Verzeichnis:\n {Directory.GetCurrentDirectory()}");

            string salesFullFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + salesFile;
            string ebitFullFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar + ebitFile;

            if (!File.Exists(salesFullFile))
            {
                throw new FileNotFoundException($"{salesFullFile} konnte nicht gefunden werden!");
            }

            StreamReader sr = new StreamReader(salesFullFile);
            StreamWriter sw = new StreamWriter(ebitFullFile);


            sw.WriteLine($" Anzahl | Artikel         | Umsatz ");
            sw.WriteLine($"--------+-----------------+--------");

            int count = 0; string art = ""; double cost = 0;
            do
            {
                string[] element = sr.ReadLine().Split(";");
                if (element[0] != art)
                {
                    sw.WriteLine($"{count,7} | {art,-15} | {cost,6}");
                    count = 0;
                    art = "";
                    cost = 0;
                }

                count++;
                art = element[0];
                cost += Convert.ToDouble(element[1]);

                if (sr.Peek() == -1) sw.WriteLine($"{count,7} | {art,-15} | {cost,6}");

            } while (!sr.EndOfStream);

            sr.Close();
            sw.Close();

            string[] texte = { "ANNA", "Anna", "UHU", "legal", "Otto", "Lagerregal", "123421" };
            
            foreach(string elm in texte)
            {
                Console.WriteLine($"{elm} is {IstPalindrom(elm)}");
            }


        }

        static bool IstPalindrom(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char a = char.ToUpper(s[i]), b = char.ToUpper(s[s.Length - 1 - i]);
                if (a != b) return false;
            }


            return true;
        }

    }
}
