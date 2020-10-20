using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Shared;

namespace Trains.Client.Models
{
    public interface ITrainsModel
    {
        Task RetrieveTrainsAsync();
        Task AddTrainAsync(TrainEntity train);
        Task<TrainEntity> GetTrainAsync(Guid id);
        Task UpdateTrainAsync(TrainEntity train);
        Task DeleteTrainAsync(TrainEntity train);
        IEnumerable<TrainEntity> Trains { get; }
    }
}
