using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Shared;

namespace Trains.Client.Models
{
    public interface ITrainsModel
    {
        Task RetrieveTrainsAsync();
        Task AddTrainAsync(Train train);
        Task<Train> GetTrainAsync(Guid id);
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(Train train);
        IEnumerable<Train> Trains { get; }
    }
}
