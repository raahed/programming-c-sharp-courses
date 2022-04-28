using System;
using System.IO;

namespace übung11
{
    enum Gender { Herr, Frau, Unbekannt }

    struct User
    {
        int userId;
        Gender gender;
        string name;
        string email;

        public User(int userId = 0, string name = "", Gender gender = Gender.Unbekannt, string email = "")
        {
            this.userId = userId;
            this.name = name;
            this.gender = gender;
            this.email = email;
        }

        static void SetzeEmail(User user, string email)
        {
            user.email = email;
        }

        public override string ToString()
        {
            return $"{this.userId}: {this.gender} {this.name} ({this.email})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            string date = "0707";
            Helgoland(date, out double height, out string time);
            Console.WriteLine($"{date} {height} {time}");


            foreach (string name in new string[] { "Günter", "Dieter", "Werner", "Berbel" })
            {
                User user = new User(rand.Next(1000,3000), name, (Gender)rand.Next(0,2));
                Console.WriteLine(user.ToString());
            }
        }

        static void Helgoland(string date, out double height, out string time)
        {
            height = 0;
            time = "";

            StreamReader sr = new StreamReader(@"..\..\..\Helgoland.txt");

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split('\t');

                if (line[0] == date)
                {
                    int lowestPointer = 2;

                    for (int i = 2; i < line.Length; i += 2)
                    {
                        if (Convert.ToDouble(line[i]) < Convert.ToDouble(line[lowestPointer]))
                        {
                            lowestPointer = i;
                        }
                    }

                    height = Convert.ToDouble(line[lowestPointer]);
                    time = line[lowestPointer - 1];

                    break;
                }
            }
        }
    }
}
