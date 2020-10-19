using System.Collections.Generic;
using Trains.Shared;
using Trains.Shared.Enums;

namespace Trains.Server.Services
{
    public class TrainsStorageService : ITrainsStorageService
    {
        public TrainsStorageService()
        {
            Trains = new HashSet<Train>() { new Train("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius") };
        }

        public HashSet<Train> Trains { get; }
    }
}
