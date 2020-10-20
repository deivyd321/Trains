using System.Collections.Generic;
using Trains.Shared;
using Trains.Shared.Enums;

namespace Trains.Server.Services
{
    public class TrainsStorageService : ITrainsStorageService
    {
        public TrainsStorageService()
        {
            Trains = new HashSet<TrainEntity>() { 
                new TrainEntity("Lotus", 1999, TrainColor.Blue, "ARS456", "LG", "Vilnius"),
                new TrainEntity("BMW", 1995, TrainColor.Green, "LOL", "VVVT", "Ryga"),
                new TrainEntity("Audi", 2012, TrainColor.Red, "NUmber", "Viking", "Talin")
            };
        }

        public HashSet<TrainEntity> Trains { get; }
    }
}
