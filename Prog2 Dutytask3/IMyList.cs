using System.Collections;

namespace Prog2_Dutytask3
{
    public interface IMyList<T> : IEnumerable where T : Vehicle
    {
        // Fügt ein Element absteigend sortiert nach dem Zulassungsdatum in
        // die verkettete Liste ein. Verwenden Sie die CompareTo()-Methode um 
        // einen DateTimeWert mit einem anderen zu
        // vergleichen. Fahrzeuge mit identischem Zulassungsdatum sind hinter 
        // den bereits existierenden Fahrzeugen einzufügen.
        void Add(T newElement);

        // Löscht alle Elemente einer bestimmten Farbe aus der verketteten
        // Liste. Die Methode gibt die Anzahl der gelöschten Fahrzeuge zurück.
        // Sollten keine Fahrzeuge einer übergebenen Farbe in der Liste sein, wird eine
        // ColorNotFound-Exception geworfen.Diese ist von Ihnen zu implementieren.
        int Remove(Color id);
    }
}
