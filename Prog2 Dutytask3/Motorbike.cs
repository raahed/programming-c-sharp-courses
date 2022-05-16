
namespace Prog2_Dutytask3
{
    public class Motorbike : Vehicle
    {
        public readonly string VehicleType = "motorbike";

        public Motorbike(Color color, DateTime date) : base(color, date) { }

        public override string GetInfo()
        {
            return $"This is a {VehicleColor} {VehicleType}, registered {RegistrationDate}.";
        }
    }
}
