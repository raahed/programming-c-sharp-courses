using System.Text;

namespace prog2_dutytask_1
{
    /// <summary>
    /// Repräsentiert die Karte.
    /// </summary>
    class Karte
    {
        /// <summary>
        /// Karte als String-Array.
        /// </summary>
        private string[] karte = new string[50];

        /// <summary>
        /// Startpositionen als Vektor Objekte.
        /// </summary>
        private Vektor[] startPos = new Vektor[10];

        /// <summary>
        /// Vektor der Zielposition.
        /// </summary>
        public Vektor zielPos { get; private set; }

        /// <summary>
        /// Echte Anzahl der Zeilen der Karte, <= 50.
        /// </summary>
        public int anzZeilen { get; private set; }

        /// <summary>
        /// Ließt die übergebene Kartendatei ein. Speichert die Karte in 'karte' und
        /// speicher die Startpositionen in 'startPos' und den Zielvektor in 'zielPos'.
        /// Zusätzlich wird die Anzahl der Zeilen der Karte in 'anzZeilen' gespeichert.
        /// </summary>
        /// <param name="kartenName">Pfad zu der Kartendatei als '.txt'</param>
        /// <exception cref="FileNotFoundException">Falls die Karte nicht gefunden wurde.</exception>
        public Karte(string kartenName)
        {
            if (!File.Exists(kartenName))
                throw new FileNotFoundException($"Die Karte konnte nicht gefunden werden: {kartenName}");

            StreamReader sr = new StreamReader(kartenName);

            for (int i = 0, spz = 0; !sr.EndOfStream; i++)
            {
                string zeile = sr.ReadLine();

                // Geht die chars der Zeile durch und speichert
                // Zielposition und Startpositionen.
                for (int j = 0; j < zeile.Length; j++)
                {
                    if (zeile[j] == 'Z')
                        zielPos = new Vektor(j, i);

                    if (zeile[j] >= '1' && zeile[j] <= '9')
                    {
                        startPos[spz] = new Vektor(j, i);
                        spz++;
                    }
                }

                // Übergeben der Zeile in den Klassen-Parameter.
                karte[i] = zeile;

                anzZeilen++;
            }

            sr.Close();
        }

        /// <summary>
        /// Gibt einen Vektor einer Startposition, oder null zurück.
        /// </summary>
        /// <param name="i">Index der Startposition.</param>
        /// <returns>Gibt einen Vektor einer Startposition, oder null zurück.</returns>
        public Vektor this[int i]
        {
            get { return startPos[i]; }
        }

        /// <summary>
        /// Übergibt die Karte 'karte' als StringBuilder-Array.
        /// </summary>
        /// <returns>StringBuilder[]-Objekt</returns>
        public StringBuilder[] CloneKarteToStringBuilder()
        {
            StringBuilder[] sb = new StringBuilder[karte.Length];

            // Gehe jede Zeile durch
            for (int i = 0; i < karte.Length; i++)
                sb[i] = new StringBuilder(karte[i]);

            return sb;
        }

        /// <summary>
        /// Gibt eine Liste der Hindernisse in Reichweite zurück.
        /// </summary>
        /// <param name="zentrum">Vektor der aktuellen Posiotion</param>
        /// <param name="reichweite">Reichweite, von der aus nach Hindernissen gesucht werden soll</param>
        /// <returns>Liste mit Vektoren der Hindernisse</returns>
        public IEnumerable<Vektor> Hindernisliste(Vektor zentrum, int reichweite)
        {
            for (int z = (int)(zentrum.y - reichweite); z <= (int)(zentrum.y + reichweite); z++)
                if (z >= 0 && z < anzZeilen)
                {
                    string zeile = karte[z];
                    for (int x = (int)(zentrum.x - reichweite); x <= (int)(zentrum.x + reichweite); x++)
                        if (x >= 0 && x < zeile.Length)
                            if (zeile[x] == 'X')
                                yield return new Vektor(x, z);
                }
        }
    }
}
