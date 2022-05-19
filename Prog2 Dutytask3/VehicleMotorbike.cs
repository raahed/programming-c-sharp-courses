
namespace Prog2_Dutytask3
{
    public class Motorbike : Vehicle
    {
        public Motorbike(Color color, DateTime date) : base(color, date) { }

        /// <summary>
        /// Returns some informations about the motorbike
        /// </summary>
        /// <returns>string returns</returns>
        public override string GetInfo()
        {
            return $"This is a {VehicleColor} motorbike, registered {RegistrationDate:yyyy-M-d}.";
        }
    }
}
