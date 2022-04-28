using System;

Console.WriteLine("Willkommen zu Ultimate Racing!");

Random rand = new Random();

// Run the Game while gameon is true
bool gameOn = true;

// Game loop
do
{
    char key;

    // Predefine and reset game enviorments aka the positions of the objects
    // the street, inclusiv boundary is 20
    int roadBoundaryLeft = 10;
    int roadBoundaryRight = 29;
    int car = 20;

    // Round counter
    int rounds = 0;

    // Where the street goes, possible values: -1 = left, 0 = stay, 1 = right 
    int streetDirection = 0;

    Console.Write("Drücke eine Taste zum Starten! ");

    Console.ReadKey(true);

    Console.WriteLine("\nLos geht's: Lenke mit A (links) und D (rechts)");

    // Main game loop, if the car hits the boundary, break
    // Every loop is a round
    while (true)
    {
        // Read the user input, set the car position
        if (Console.KeyAvailable)
        {
            key = Console.ReadKey(true).KeyChar;

            if (key == 'a')
                car--;
            else if (key == 'd')
                car++;
        }

        // Handle the Street direction every fifth round
        if (rounds % 5 == 0)
        {
            // When the boundary hits the left of the command line, only stay or right is possible
            if (roadBoundaryLeft <= 1)
                streetDirection = rand.Next(0, 2);

            // When the street goes to far right, only left or stay is possible
            else if (roadBoundaryRight >= 100)
                streetDirection = rand.Next(-1, 1);
            else
                streetDirection = rand.Next(-1, 2);
        }

        // Dispatch the street direction every round
        roadBoundaryLeft += streetDirection;
        roadBoundaryRight += streetDirection;

        // Draw the boundary, car and spaces between them        
        Console.Write(new string(' ', roadBoundaryLeft) + ".");             // Left boundary
        Console.Write(new string(' ', car - roadBoundaryLeft + 1) + "X");   // Car
        Console.Write(new string(' ', roadBoundaryRight - car) + ".\n");    // Right boundary

        // Game over condition, car-boundary hit, break game loop
        if (car <= roadBoundaryLeft || car >= roadBoundaryRight)
        {
            Console.WriteLine("CRASH!");
            Console.WriteLine($"{rounds} Runden geschafft!");
            break;
        }

        // Await 200ms before the next round
        System.Threading.Thread.Sleep(200);

        rounds++;
    }

    // Buffer all previous key input, otherwise the input is bugy
    while (Console.KeyAvailable) Console.ReadKey(true);

    // Await 800ms after game end
    System.Threading.Thread.Sleep(800);

    // Retry game or exit
    while (true)
    {
        Console.Write("Spiel wiederholen (j/n)?");

        key = Console.ReadKey().KeyChar;

        Console.WriteLine();

        if (key == 'j')
            break;
        else if (key == 'n')
        {
            // Set gameon to false to exit the game loop
            gameOn = false;
            break;
        }
    }
} while (gameOn);