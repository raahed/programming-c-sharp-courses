namespace Prog2_Practis8
{
    public class Fracture : IComparable
    {
        private int _numerator;
        private int _denominator;

        // "Zähler"
        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }

        // "Nenner"
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0)
                    throw new DivideByZeroException();

                _denominator = value;
            }
        }

        public Fracture()
        {
            Numerator = Denominator = 1;
        }

        public Fracture(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return $"Bruch: {Numerator}/{Denominator} = {(double)Numerator/Denominator}";
        }

        int IComparable.CompareTo(object? obj)
        {
            // Testing is null or not type of Fracture
            if (obj is null || obj is not Fracture fracture)
                throw new NullReferenceException(nameof(obj));

            // If value is equal
            if (Numerator / Denominator == fracture.Numerator / fracture.Denominator)
                return 0;

            // If value is smaller
            if (Numerator / Denominator < fracture.Numerator / fracture.Denominator)
                return -1;

            // If value is greater
            else
                return 1;
        }
    }
}
