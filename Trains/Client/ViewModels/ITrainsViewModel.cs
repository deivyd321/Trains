using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Trains.Shared;

namespace Trains.Client.ViewModels
{
    public interface ITrainsViewModel
    {
        bool IsBusy { get; set; }
        Train Train { get; set; }
        IEnumerable<Train> Trains { get; set; }
        Task RetrieveTrainsAsync();
        Task GetTrainAsync(Guid id);
        Task AddOrEditTrainAsync();
        Task RemoveTrainAsync();
        Task EditTrainAsync();

        event PropertyChangedEventHandler PropertyChanged;
    }
}
