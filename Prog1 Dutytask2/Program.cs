using System;

/*
 * Catching inputs
 */
Console.Write("Welcher Betrag soll angelegt werden? ");

//Replace ',' to '.' to make the usage more flexible
if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out double investAmount))
{
    Console.WriteLine("Die Eingabe war leider fehlerhaft. Es sind zur Beträge möglich.");
    Environment.Exit(0);
}

Console.Write("Wielange soll die Laufzeit sein? (Ohne Vertragslaufzeit bitte '0' angeben!) ");

if (!int.TryParse(Console.ReadLine(), out int contractTime))
{
    Console.WriteLine("Die Eingabe war leider fehlerhaft! Es sind nur Jahre möglich.");
    Environment.Exit(0);
}

//In case of ugly amount or years input
if (investAmount <= 0 || contractTime < 0)
{
    Console.WriteLine("Leider können wir mit den Angaben nicht arbeiten!");
}

/*
 * Casing the best strategy
 */
if (contractTime == 0)
{
    if (investAmount >= 5000)
    {
        Console.WriteLine("Am besten ist für dich das Tagesgeld geeignet, mit 0,1% Zins.");
    }
    else
    {
        Console.WriteLine("Am besten ist für dich der Sparstrumpf geeignet, mit 0% Zins.");
    }
}
else if (contractTime >= 5 && contractTime < 10)
{
    if (investAmount >= 2000 && investAmount < 5000)
    {
        Console.WriteLine("Am besten ist für dich der Sparbrief geeignet, mit 0,9% Zins.");

    }
    else if (investAmount >= 5000)
    {
        Console.WriteLine("Am besten ist für dich die Bundesobligationen geeignet, mit 1,5% Zins.");
    }
    else
    {
        Console.WriteLine("Leider können wir dir keine Anlagestrategie anbieten.");
    }
}
else if (contractTime >= 10)
{
    if (investAmount >= 1000)
    {
        Console.WriteLine("Am besten ist für dich der Bundesschatzbrief geeignet, mit 2,1% Zins.");
    }
    else
    {
        Console.WriteLine("Leider können wir dir keine Anlagestrategie anbieten.");
    }
}
else
{
    Console.WriteLine("Leider können wir dir keine Anlagestrategie anbieten.");
}
