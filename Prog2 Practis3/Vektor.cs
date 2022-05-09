namespace study_prog2_practis_3
{
    public class Vektor
    {
        public double x;
        public double y;
        public double z;

        public Vektor()
        {
            x = y = z = 0;
        }

        public Vektor(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"Vektor bei {x}, {y}, {z}";
        }

        public static Vektor operator +(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vektor operator *(Vektor v, int scalar)
        {
            return new Vektor(v.x * scalar, v.y * scalar, v.z * scalar);
        }

        public static Vektor CrossProduct(Vektor v1, Vektor v2)
        {
            return new Vektor(
                v1.y * v2.z - v1.z * v2.y,
                v1.z * v2.x - v1.x * v2.z,
                v1.x * v2.y - v1.y * v2.x);
        }

        public static double Dist(Vektor v)
        {
            return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }
    }
}
