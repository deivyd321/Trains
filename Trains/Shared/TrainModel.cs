using Trains.Shared.Enums;

namespace Trains.Shared
{
    public class TrainModel
    {

        public int Year { get; private set; }
        public int PowerKWh { get; private set; }
        public Color Color { get; private set; }
        public string HomeCity { get; private set; }
        public string Company { get; private set; }
    }
}
