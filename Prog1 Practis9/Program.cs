using System;

namespace übung9
{
    class Program
    {
        enum Farbe
        {
            Schwarz,
            Rot,
            Blau
        }

        struct Kreis
        {
            public double radius;
            public double x, y;
            public Farbe farbe;
        }

        struct Bruch
        {
            public double zaehler;
            public double nenner;
        }

        static void Main(string[] args)
        {
            //Kreis
            Kreis[] kreise = new Kreis[3];

            for (int i = 0; i < kreise.Length; i++)
            {
                kreise[i] = NeuerKreis(new Random().NextDouble(), new Random().Next(), new Random().Next());
            }

            double small = 0; int smallest = 0;
            for (int i = 0; i < kreise.Length; i++)
            {
                double current = Umfang(kreise[i]);
                if (current < small)
                {
                    small = current;
                    smallest = i;
                }
            }

            SetzeUmfang(ref kreise[smallest], 30);
            Console.WriteLine($"{kreise[smallest].radius}, {Umfang(kreise[smallest])}, {kreise[smallest].farbe}");


            //Bruch
            Bruch b1;
            b1.zaehler = 4;
            b1.nenner = 3;
            Console.WriteLine("b1 = " + ToString(b1));

            Bruch b2;
            (b2.zaehler, b2.nenner) = (3, 2);
            Console.WriteLine("b2 = " + ToString(b2));
            Console.WriteLine("mult = " + ToString(Mult(b1, b2)));
            Console.WriteLine("add = " + ToString(Add(b1, b2)));

            Bruch b4;
            b4 = Add(b1, b2);
            Console.WriteLine("b4 = " + ToString(Add(b4, new Bruch { zaehler = 1, nenner = 6 })));


        }

        static string ToString(Bruch bruch)
        {
            return $"{bruch.zaehler}{(bruch.nenner != 1 ? "/" + bruch.nenner : "")}";
        }

        static Kreis NeuerKreis(double radius, double x, double y, Farbe farbe = Farbe.Schwarz)
        {
            Kreis k;
            k.radius = radius;
            (k.x, k.y) = (x, y);
            k.farbe = farbe;

            return k;
        }

        static double Umfang(Kreis k)
        {
            return 2 * Math.PI * k.radius;
        }

        static void SetzeUmfang(ref Kreis k, double umfang)
        {
            k.radius = umfang / (2 * Math.PI);
        }

        static Bruch Mult(Bruch b1, Bruch b2)
        {
            Bruch b3;
            b3.zaehler = b1.zaehler * b2.zaehler;
            b3.nenner = b1.nenner * b2.nenner;

            Kürze(ref b3);

            return b3;
        }

        static Bruch Add(Bruch b1, Bruch b2)
        {
            Bruch b3;
            b3.nenner = b1.nenner * b2.nenner;
            b3.zaehler = b2.zaehler * b1.nenner + b1.zaehler * b2.nenner;

            Kürze(ref b3);

            return b3;
        }

        static void Kürze(ref Bruch b)
        {
            double ggt = 0;

            double z = b.zaehler, n = b.nenner;
            if (z == 0)
            {
                ggt = n;
            }
            else
            {
                while (n != 0)
                {
                    if (z > n)
                    {
                        z -= n;
                    }
                    else
                    {
                        n -= z;
                    }
                }
                ggt = z;
            }

            b.zaehler /= ggt;
            b.nenner /= ggt;
        }
    }
}
