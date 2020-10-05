using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trains.Client.Models;
using Trains.Shared;

namespace Trains.Client.ViewModels
{
    public interface ITrainViewModel
    {
        IEnumerable<Train> Trains { get; set; }
        Task RetrieveTrainsAsync();
        Task AddTrainAsync(Train train);
    }
    public class TrainsViewModel : ITrainViewModel
    {
        private ITrainsModel _trainsModel;

        private IEnumerable<Train> _trains;
        public IEnumerable<Train> Trains
        {
            get => _trains;
            set => _trains = value;
        }
        public TrainsViewModel(ITrainsModel trainsModel)
        {
            _trainsModel = trainsModel;
        }

        public async Task RetrieveTrainsAsync()
        {
            await _trainsModel.RetrieveTrainsAsync();
            _trains = _trainsModel.Trains;
        }

        public async Task AddTrainAsync(Train train)
        {
            await _trainsModel.AddTrainAsync(train);
            await RetrieveTrainsAsync();
        }
    }
}
