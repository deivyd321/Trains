using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Trains.Client.Models;
using Trains.Shared;

namespace Trains.Client.ViewModels
{
    public class TrainsViewModel : BaseViewModel, ITrainsViewModel
    {
        private ITrainsModel _trainsModel;
        private Train _train = new Train();
        private IEnumerable<Train> _trains;

        public IEnumerable<Train> Trains
        {
            get => _trains;
            set => _trains = value;
        }

        public Train Train
        {
            get => _train;
            set
            {
                SetValue(ref _train, value);
            }
        }

        public TrainsViewModel(ITrainsModel trainsModel)
        {
            _trainsModel = trainsModel;
        }

        public async Task RetrieveTrainsAsync()
        {
            await _trainsModel.RetrieveTrainsAsync();
            _trains = _trainsModel.Trains;
            OnPropertyChanged(nameof(Trains));
        }

        public async Task GetTrainAsync(Guid id)
        {
            Train = await _trainsModel.GetTrainAsync(id);
        }

        public async Task AddOrEditTrainAsync()
        {
            IsBusy = true;
            if (_train.Id.Equals(Guid.Empty))
            {
                _train.Id = Guid.NewGuid();
                await _trainsModel.AddTrainAsync(_train);
            }
            else
            {
                await _trainsModel.UpdateTrainAsync(_train);
            }
            Train = new Train();
            await RetrieveTrainsAsync();
            IsBusy = false;
        }

        public async Task RemoveTrainAsync()
        {
            IsBusy = true;
            await _trainsModel.DeleteTrainAsync(_train);
            Train = new Train();
            await RetrieveTrainsAsync();
            IsBusy = false;
        }

        public async Task EditTrainAsync()
        {
            IsBusy = true;
            await _trainsModel.UpdateTrainAsync(_train);
            await RetrieveTrainsAsync();
            IsBusy = false;
        }
    }
}
