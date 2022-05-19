namespace Prog2_Dutytask3
{
    public class Car : Vehicle
    {
        public Car(Color color, DateTime date) : base(color, date) { }

        /// <summary>
        /// Returns some informations about the car
        /// </summary>
        /// <returns>string returns</returns>
        public override string GetInfo()
        {
            return $"This is a {VehicleColor} car, registered {RegistrationDate:yyyy-M-d}.";
        }
    }
}
