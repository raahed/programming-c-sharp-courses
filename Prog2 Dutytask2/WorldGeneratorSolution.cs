namespace Game
{
    // World building helper class:

    static class WorldGenerator
    {
        // Indices for the location array (see below) - NOTE: Using this location indices is optional - You can also use another, i.e. your own implemention...

        const int dungeon_entrance = 0;  // Start location
        const int hall = 1;
        const int storage_room = 2;
        const int staff_room = 3;
        const int armory = 4;
        const int bedroom = 5;
        const int throne_room = 6;
        const int secret_chamber = 7;  // Unreachable
        const int count = 8;


        // Build dungeon world:

        public static World BuildDungeon()
        {
            // Pre-allocate locations:

            Location[] locations = new Location[count];  // NOTE: Using this location array is optional - You can also use another, i.e. your own implemention...

            for (int i = 0; i < count; i++)
                locations[i] = new Location();

            // Setup dungeon entry location (name and entity array):

            locations[dungeon_entrance].Name = "dungeon entrance";
            locations[dungeon_entrance].Entities = new Entity[] { new Portal(locations[hall]) };

            // Setup hall location (name and entity array):

            locations[hall].Name = "hall";
            locations[hall].Entities = new Entity[]
                {
                    new Passage(locations[dungeon_entrance]),
                    new Door(locations[storage_room]),
                    new Door(locations[staff_room]),
                    new Door(locations[armory]),
                    new Door(locations[throne_room], false),

                    new Gold.Coin()
                };


            // Setup storage room location (name and entity array):

            locations[storage_room].Name = "storage room";
            locations[storage_room].Entities = new Entity[]
                {
                    new Passage(locations[staff_room]),
                    new Door(locations[hall]),

                    new Gold.Coin(),
                    new Gold.Coin(),
                    new Gold.Chest(50)
                };

            // Setup staff room location (name and entity array):

            locations[staff_room].Name = "staff room";
            locations[staff_room].Entities = new Entity[]
                {
                    new Passage(locations[storage_room]),
                    new Door(locations[storage_room]),
                    new Door(locations[throne_room]),

                    new Gold.Coin(),
                    new Gold.Chest(20)
                };

            // Setup armory location (name and entity array):

            locations[armory].Name = "armory";
            locations[armory].Entities = new Entity[] { new Door(locations[hall]) };

            // Setup bedroom location (name and entity array):

            locations[bedroom].Name = "bedroom";
            locations[bedroom].Entities = new Entity[]
                {
                    new Door(locations[throne_room]),

                    new Gold.Coin(),
                    new Gold.Chest(50),
                    new Gold.Chest(50)
                };

            // Setup throne room location (name and entity array):

            locations[throne_room].Name = "throne room";
            locations[throne_room].Entities = new Entity[]
                {
                    new Door(locations[staff_room]),
                    new Door(locations[bedroom]),
                    new Door(locations[hall], false),
                    new Door(locations[secret_chamber], false),

                    new Gold.Coin(),
                    new Gold.Coin(),
                    new Gold.Coin(),
                    new Gold.Coin(),
                    new Gold.Coin(),
                    new Gold.Chest(100),
                    new Gold.Chest(100),
                    new Gold.Chest(120)
                };

            // Setup secret chamber (unreachable) location (name and entity array):

            locations[secret_chamber].Name = "secret chamber";
            locations[secret_chamber].Entities = new Entity[]
                {
                    new Door(locations[throne_room], false),

                    new Gold.Chest(1000)
                };

            // Create new world:

            World world = new World(locations[dungeon_entrance]);  // Start location      

            return world;
        }
    }
}
