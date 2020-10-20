using System.Collections.Generic;
using Trains.Shared;

namespace Trains.Server.Services
{
    public interface ITrainsStorageService
    {
        HashSet<TrainEntity> Trains { get; }
    }
}
