namespace Game
{
    // Portal base class:

    class Portal : Entity
    {
        public Location Target { get; set; }

        public Portal(Location target)
        {
            Target = target;
        }
    }


    // Passage class:

    class Passage : Portal
    {
        public Passage(Location target) : base(target) { }
    }


    // Door class:

    class Door : Portal
    {
        public bool Unlocked { get; set; }

        public Door(Location target, bool unlocked = true) : base(target)
        {
            Unlocked = unlocked;
        }
    }
}