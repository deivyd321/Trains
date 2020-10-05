using System.Collections.Generic;
using Trains.Shared;
using Trains.Shared.Enums;

namespace Trains.Server.Services
{
    public class TrainsStorageService
    {
        public HashSet<Train> Trains;

        public TrainsStorageService()
        {
            Trains = new HashSet<Train>() { new Train("Lotus", 1999, Color.Blue, "ARS456", "LG", "Vilnius") };
        }
    }
}
