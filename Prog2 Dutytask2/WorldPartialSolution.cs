using System;

namespace Game
{
    // Implementation of player actions in the game world (Partial implementation -> See also: WorldPartial.cs!)

    partial class World
    {
        // Player tries to collect all gold coins at the location where he is at the moment:

        uint tryToCollectGoldCoins(Player player)
        {
            // Traverse entity list, searching for gold coins:

            uint collectedGoldCoins = 0u;  // Number of collected gold coins at current player location...

            for (int i = 0; i < player.Location.Entities.Length; i++)
                if (player.Location.Entities[i] is Gold.Coin)
                {
                    collectedGoldCoins++;
                    player.GoldCoins++;
                    player.Location.Entities[i] = null;
                }

            return collectedGoldCoins;
        }


        // Player tries to loot all gold chests at the location where he is at the moment:

        uint tryToLootGoldChests(Player player)
        {
            // Traverse entity list, searching for gold chests:

            uint lootedGoldCoins = 0u;  // Number of looted gold coins (from treasure chests) at current player location...

            for (int i = 0; i < player.Location.Entities.Length; i++)
            {
                if (player.Location.Entities[i] is Gold.Chest chest)
                {
                    if (chest.Coins > 0)
                    {
                        player.GoldCoins += chest.Coins;
                        lootedGoldCoins += chest.Coins;
                        chest.Coins = 0;
                    }
                }
            }

            return lootedGoldCoins;
        }


        // Player picks a random portal at the location where he is at the moment:

        Random random = new Random(Guid.NewGuid().GetHashCode());  // NOTE: Use this random generator (initialized with a unique random seed)!

        Portal pickRandomPortal(Player player)
        {
            // Count portals in current location:

            uint counter = 0;

            foreach (Entity entity in player.Location.Entities)
                if (entity is Portal)
                    counter++;

            if (counter < 1)
                return null;

            // Pick n-th portal from entity array:

            int randomSeed = random.Next(1, (int)counter + 1), loop = 0;

            foreach (Entity entity in player.Location.Entities)
                if (entity is Portal portal)
                {
                    loop++;
                    if (loop == randomSeed)
                        return portal;
                }


            return null;
        }


        // Player tries to pass the portal at the location he is currently at:

        bool tryToPassPortal(Player player, Portal portal)
        {
            // Check if portal is valid and, if it is a door, then if is not locked:

            if (portal == null)
                return false;

            if (portal is Door door)
            {
                if (!door.Unlocked)
                    return false;
            }

            // Change player location:

            player.Location = portal.Target;

            return true;  // Successful portal pass...
        }
    }
}