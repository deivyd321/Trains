using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Server.DataModels;
using Trains.Shared;

namespace Trains.Server.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly TrainContext _trainContext;
        public TrainRepository(TrainContext trainContext)
        {
            _trainContext = trainContext;
        }

        public async Task<List<TrainEntity>> GetAllAsync()
        {
            return await _trainContext.Trains.ToListAsync();
        }

        public async Task<TrainEntity> GetAsync(Guid id)
        {
            return await _trainContext.Trains.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(TrainEntity trainEntity)
        {
            await _trainContext.Trains.AddAsync(trainEntity);
        }

        public void Update(TrainEntity trainEntity)
        {
            _trainContext.Trains.Update(trainEntity);
        }

        public void Delete(TrainEntity trainEntity)
        {
            _trainContext.Trains.Remove(trainEntity);
        }

        public async Task SaveAsync()
        {
            await _trainContext.SaveChangesAsync();
        }
    }
}
