namespace prog2_dutytask_1
{
    /// <summary>
    /// Repräsentiert einen Vektor mit zwei Dimensionen.
    /// </summary>
    class Vektor
    {
        public double x, y;

        /// <summary>
        /// Inizialisiert einen Vektor mit x und y Werten.
        /// </summary>
        /// <param name="x">Erste Dimension.</param>
        /// <param name="y">Zweite Dimension.</param>
        public Vektor(double x, double y)
        {
            this.x = x; 
            this.y = y;
        }

        /// <summary>
        /// Überschreibt die ToString Methode.
        /// </summary>
        /// <returns>Vektor als String.</returns>
        public override string ToString()
        {
            return $"Der Vektor liegt bei {x} und {y}";
        }

        /// <summary>
        /// Hilfsmethode: Setzt x und y des Vektores auf einen Wert.
        /// </summary>
        /// <param name="wert">Wert für x und y.</param>
        public void InitAll(double wert)
        {
            x = y = wert;
        }

        /// <summary>
        /// Berechnet die Norm (Länge) des Vektors.
        /// </summary>
        /// <param name="v">Vektor Objekt.</param>
        /// <returns> Gibt die Norm (Länge) ungerundet zurück.</returns>
        public static double Dist(Vektor v)
        {
            return Math.Sqrt(v.x * v.x + v.y * v.y);
        }

        /// <summary>
        /// Berechnet die Norm zwischen zwei Vektoren.
        /// </summary>
        /// <param name="p1">Erstes Vektor Objekt.</param>
        /// <param name="p2">Zweites Vektor Objekt.</param>
        /// <returns> Gibt die Norm (Länge) ungerundet zurück.</returns>
        public static double Dist(Vektor p1, Vektor p2)
        {
            return Dist(new Vektor(p2.x - p1.x, p2.y - p1.y));
        }

        /// <summary>
        /// Subtrahiert den zweiten Vektor vom ersten Vektor.
        /// 
        /// Überschreibt den '-' Operator.
        /// </summary>
        /// <param name="p1">Erstes Vektor Objekt.</param>
        /// <param name="p2">Zweites Vektor Objekt.</param>
        /// <returns>Gibt ein neues Vektor Objekt zurück.</returns>
        public static Vektor operator -(Vektor p1, Vektor p2)
        {
            return new Vektor(p1.x - p2.x, p1.y - p2.y);
        }

        /// <summary>
        /// Addiert zwei Objekte vom Typ Vektor.
        /// 
        /// Überschreibt den '+' Operator.
        /// </summary>
        /// <param name="p1">Erstes Vektor Objekt.</param>
        /// <param name="p2">Zweites Vektor Objekt.</param>
        /// <returns>Gibt ein neues Vektor Objekt zurück.</returns>
        public static Vektor operator +(Vektor p1, Vektor p2)
        {
            return new Vektor(p1.x + p2.x, p1.y + p2.y);
        }

        /// <summary>
        /// Multipliziert ein Vektor Objekt mit einem Parameter.
        /// 
        /// Überschreibt den '*' Operator.
        /// </summary>
        /// <param name="p">Vektor Objekt.</param>
        /// <param name="wert">Parameterwert als double.</param>
        /// <returns>Gibt ein neues Vektor Objekt zurück.</returns>
        public static Vektor operator *(Vektor p, double wert)
        {
            return new Vektor(p.x * wert, p.y * wert);
        }

        /// <summary>
        /// Vergleicht zwei Vektor Objekte auf gleichheit.
        /// Vergleicht auch auf null.
        /// 
        /// Überschreibt den '==' Operator.
        /// </summary>
        /// <param name="p1">Erstes Vektor Objekt.</param>
        /// <param name="p2">Zweites Vektor Objekt.</param>
        /// <returns>Gibt einen boolischen Wert zurück.</returns>
        public static bool operator ==(Vektor p1, Vektor p2)
        {
            if (p1 is null && p2 is null)
                return true;

            if (p1 is null || p2 is null)
                return false;

            return (p1.x == p2.x && p1.y == p2.y);
        }

        /// <summary>
        /// Vergleicht zwei Vektor Objekte auf ungleichheit.
        /// Vergleicht auch auf null.
        /// 
        /// Implementiert den '==' Operator!
        /// 
        /// Überschreibt den '!=' Operator.
        /// </summary>
        /// <param name="p1">Erstes Vektor Objekt.</param>
        /// <param name="p2">Zweites Vektor Objekt.</param>
        /// <returns>Gibt einen boolischen Wert zurück.</returns>
        public static bool operator !=(Vektor p1, Vektor p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Normalisiert den Vektor um den gegebenen Faktor.
        /// </summary>
        /// <param name="n">Faktor der Normalisierung. Standardwert 1.0.</param>
        public void Normalisieren(double n = 1.0)
        {
            double d = Math.Sqrt(x * x + y * y) / n;
            x /= d;
            y /= d;
        }
    }
}
