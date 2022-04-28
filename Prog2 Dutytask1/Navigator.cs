using System.Text;

namespace prog2_dutytask_1
{
    /// <summary>
    /// Klasse, welche die Navigation
    /// durch die Karte ausführt.
    /// </summary>
    class Navigator
    {
        /// <summary>
        /// Objekt der Karte.
        /// </summary>
        Karte meineKarte;

        /// <summary>
        /// Aktuelle Position als Vektor Objekt.
        /// </summary>
        Vektor aktPosition;

        /// <summary>
        /// Ziel Position als Vektor Objekt.
        /// </summary>
        Vektor zielPosition;

        /// <summary>
        /// Die Karte als StringBuilder-Array.
        /// </summary>
        StringBuilder[] ausgKarte;

        /// <summary>
        /// Initalisiert den Navigator mit der Karte und dem Vektor der Start Position.
        /// </summary>
        /// <param name="karte">Objekt der Karte.</param>
        /// <param name="kartenindex">Index der Start Position.</param>
        public Navigator(Karte karte, int kartenindex)
        {
            meineKarte = karte;
            ausgKarte = karte.CloneKarteToStringBuilder();
            aktPosition = karte[kartenindex];
            zielPosition = karte.zielPos;
        }

        /// <summary>
        /// Vergleicht den Vektor der aktuellen Position mit dem
        /// Vektor der Ziel Position.
        /// </summary>
        /// <returns>boolisch, oder das Ziel erreicht wurde.</returns>
        public bool ZielErreicht()
        {
            if (Vektor.Dist(aktPosition, zielPosition) < 1.0)
                return true;
            return false;
        }

        /// <summary>
        /// Berechnet den nächsten Vektor zum Ziel
        /// unter Umgehung der Hindernissen.
        /// </summary>
        public void NaechsterKurs()
        {
            Vektor zielVektor = zielPosition - aktPosition;
            zielVektor.Normalisieren(6);

            // Geht die Liste mit den aktuellen Hindernissen durch
            // Versucht die aktuellen Hindernisse zu umgehen
            foreach (Vektor hindernis in meineKarte.Hindernisliste(aktPosition, 3))
            {
                Vektor hindernisVektor = aktPosition - hindernis;
                double d = Vektor.Dist(hindernisVektor);
                hindernisVektor.Normalisieren();
                hindernisVektor = hindernisVektor * (4 - d);
                zielVektor = zielVektor + hindernisVektor;
            }

            // Berechnet den neuen Vektor
            zielVektor.Normalisieren();
            aktPosition += zielVektor;

            // Fügt der Ausgabe-Karte die neue Position hinzu
            ausgKarte[(int)(aktPosition.y + 0.5)][(int)(aktPosition.x + 0.5)] = '*';
        }

        /// <summary>
        /// Gibt die Karte und den Weg auf der Konsole aus.
        /// </summary>
        public void KarteUndWegAusgeben()
        {
            for (int i = 0; i < ausgKarte.Length; i++)
            {
                for (int j = 0; j < ausgKarte[i].Length; j++)
                {
                    Console.ResetColor();

                    // Färbt den Weg zum Ziel gelb ein
                    if (ausgKarte[i][j] == '*')
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(ausgKarte[i][j]);
                }

                // Umbruch nach jeder Zeile
                if (ausgKarte[i].Length != 0)
                    Console.Write('\n');
            }
        }

        /// <summary>
        /// Versucht einen Weg zum Ziel zu finden. Ruft die Berechnung
        /// für die Berechnung des Kurses auf, bis die Anzahl der max
        /// Versuche erreicht ist.
        /// </summary>
        /// <returns>boolische Rückgabe, ob ein Ziel gefunden wurde.</returns>
        public bool WegZumZielSuchen()
        {
            // Versucht in 150 Schritten einen
            // Weg zu Ziel zu finden
            int max = 150, versuche = 1;

            for (; versuche <= max; versuche++)
            {
                // Berechnung des nächsten Vektors
                NaechsterKurs();

                // Bricht ab, wenn das Ziel gefunden wurde
                if (ZielErreicht())
                    break;
            }

            KarteUndWegAusgeben();

            Console.WriteLine($"Anzahl Schritte: {versuche}");

            if (ZielErreicht())
                return true;

            return false;
        }
    }
}
