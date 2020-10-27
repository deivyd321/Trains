using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Shared;

namespace Trains.Server.Repositories
{
    public interface ITrainRepository
    {
        void Delete(TrainEntity trainEntity);
        Task<List<TrainEntity>> GetAllAsync();
        Task<TrainEntity> GetAsync(Guid id);
        Task InsertAsync(TrainEntity trainEntity);
        void Update(TrainEntity trainEntity);
        Task SaveAsync();
    }
}