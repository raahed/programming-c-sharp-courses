namespace Prog2_Dutytask3
{
    public abstract class Vehicle
    {
        public Color VehicleColor { get; }

        // Zum Speichern des Zulassungsdatums wird System.DateTime verwendet.
        // Hinweis: Das Zeitformat, das in der Ausgabe erzeugt wird, erhalten
        // Sie durch die Methode <DateTime-Objekt>.ToString("yyyy-M-d").
        public DateTime RegistrationDate { get; }

        // Implementierung ersichtlich anhand der Ausgabe des Programms.
        public abstract string GetInfo();

        public Vehicle(Color color, DateTime date)
        {
            this.VehicleColor = color;
            this.RegistrationDate = date;
        }

    }
}
