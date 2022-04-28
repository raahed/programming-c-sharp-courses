using System;

namespace übung10
{
    class Program
    {
        struct Datum
        {
            private int tag;
            private int monat;
            private int jahr;

            public override string ToString() => $"{this.tag}.{this.monat}.{this.jahr}";

            public Datum(int tag, int monat, int jahr)
            {
                this.tag = (tag > 0 && tag < 32 ? tag : -1);
                this.monat = (monat > 0 && monat < 13 ? monat : -1);
                this.jahr = jahr;
            }

            public void Morgen()
            {
                int[] month = { 31, 28, 31, 30, 31, 31, 30, 31, 30, 31, 30, 31 };

                if (month[this.monat - 1] < this.tag + 1)
                {
                    this.tag = 1;
                    if (this.monat + 1 > 12)
                    {
                        this.monat = 1;
                        this.jahr++;
                    }
                    else
                    {
                        this.monat++;
                    }
                }
                else
                {
                    this.tag++;
                }
            }

        }
        static void Main(string[] args)
        {
            if (Teilmenge(new int[] { 3, 4, 2, 1 }, new int[] { 1, 2 }))
            {
                Console.WriteLine("Iss drin!");
            }
            else
            {
                Console.WriteLine("Iss not drin!");
            }

            Datum d = new Datum(12, 10, 2021);
            for (int i = 0; i < 200; i++, d.Morgen()) Console.WriteLine(d);

        }

        static bool Teilmenge(int[] b, int[] search)
        {

            for (int i = 0; i < search.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < b.Length; j++)
                {
                    if (b[j] == search[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) return found;
            }

            return true;
        }
    }

}
