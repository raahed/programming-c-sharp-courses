namespace Game
{
    // Treasure base class:

    class Treasure : Entity { }


    // Gold treasures:

    namespace Gold
    {
        // Coin class:

        class Coin : Treasure { }


        // Chest class:

        class Chest : Treasure
        {
            public uint Coins { get; set; }

            public Chest(uint coins = 0)
            {
                Coins = coins;
            }
        }
    }
}