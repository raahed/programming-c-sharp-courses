namespace Prog2_Dutytask3
{
    public class Car : Vehicle
    {
        public Car(Color color, DateTime date) : base(color, date) { }

        public override string GetInfo()
        {
            return $"This is a {VehicleColor} {GetType().ToString().ToLower()}, registered {RegistrationDate}.";
        }
    }
}
