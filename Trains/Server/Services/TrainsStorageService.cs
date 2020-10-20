using System.Collections.Generic;
using Trains.Shared;
using Trains.Shared.Enums;

namespace Trains.Server.Services
{
    public class TrainsStorageService : ITrainsStorageService
    {
        public TrainsStorageService()
        {
            Trains = new HashSet<TrainEntity>() { new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius") };
        }

        public HashSet<TrainEntity> Trains { get; }
    }
}
