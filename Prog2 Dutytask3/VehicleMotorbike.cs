
namespace Prog2_Dutytask3
{
    public class Motorbike : Vehicle
    {
        public Motorbike(Color color, DateTime date) : base(color, date) { }

        public override string GetInfo()
        {
            return $"This is a {VehicleColor} motorbike, registered {RegistrationDate.ToString("yyyy-M-d")}.";
        }
    }
}
