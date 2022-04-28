using System;

/*
 * Task Part 1
 */

//Read lowerLimit, check int
Console.Write("Untere Grenze eingeben: ");
if (!int.TryParse(Console.ReadLine(), out int lowerLimit))
{
    Console.WriteLine("Eingabe ist nur in int möglich!");
    Environment.Exit(0);
}

//Read upperLimit, check int
Console.Write("Obere Grenze eingeben: ");
if (!int.TryParse(Console.ReadLine(), out int upperLimit))
{
    Console.WriteLine("Eingabe ist nur in int möglich!");
    Environment.Exit(0);
}

//Exit, if the input has logical errors
if (upperLimit <= lowerLimit)
{
    Console.WriteLine("Die Eingabe der Limits ist ungültig.");
    Environment.Exit(0);
}

//Loop numbers and print out if i mod 7 = 0
for (int i = lowerLimit + 1; i < upperLimit; i++)
{
    if (i % 7 == 0) Console.Write(i + " ");
}

Console.WriteLine("\n");

/* 
 * Task Part 2
 */

//Read number, check positive int
Console.Write("Positive Zahl eingeben: ");
if (!uint.TryParse(Console.ReadLine(), out uint number))
{
    Console.WriteLine("Eingabe ist nur in uint möglich!");
    Environment.Exit(0);
}

//Loop print numbers
for (int i = (int)number; i > 0; i--)
{
    //print a linebreak after every fifth number
    //skip the first case with i != (int)number
    if ((i - (int)number) % 5 == 0 && i != (int)number) Console.Write("\n");

    //Formatstring
    Console.Write($"{i,5}");
}


/*
 * Task Part 2
 */

Console.WriteLine("Rate die Zahl!");
Console.WriteLine("==============");


//Read maxLimit, check positive int
Console.Write("Gib eine obere Grenze an: ");
if (!uint.TryParse(Console.ReadLine(), out uint maxLimit))
{
    Console.WriteLine("Eingabe ist nur in uint möglich!");
    Environment.Exit(0);
}

//Creat random number 
Random rand = new Random();
int randNumber = rand.Next(1, (int)maxLimit);
Console.WriteLine($"Welche Zahl zwischen 1 und {maxLimit} habe ich mir ausgesucht?");


//Loop console input goes in trynumber
uint tryNumber, i = 0;
do
{
    i++;

    Console.Write($"{i}. Versuch: ");

    //Read trynumber, check int
    if (!uint.TryParse(Console.ReadLine(), out tryNumber))
    {
        Console.WriteLine("Keine gültige Zahl!");
    }

    if (tryNumber < randNumber)
    {
        Console.WriteLine("Zu klein!");
    }
    else if (tryNumber > randNumber)
    {
        Console.WriteLine("Zu groß!");
    }
    else
    {
        Console.WriteLine($"Richtig! Du hast {i} Versuche gebraucht.");
    }

} while (tryNumber != randNumber);