namespace Prog2_Dutytask3
{
    public class Car : Vehicle
    {
        public readonly string VehicleType = "car";

        public Car(Color color, DateTime date) : base(color, date) { }

        public override string GetInfo()
        {
            return $"This is a {VehicleColor} {VehicleType}, registered {RegistrationDate}.";
        }
    }
}
