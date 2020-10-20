using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Trains.Shared;

namespace Trains.Client.Models
{
    public class TrainsModel : ITrainsModel
    {
        private HttpClient _http;

        private IEnumerable<TrainEntity> _trains;
        public IEnumerable<TrainEntity> Trains { get => _trains; }

        public TrainsModel(HttpClient http)
        {
            _http = http;
        }
        public async Task RetrieveTrainsAsync()
        {
            _trains = await _http.GetFromJsonAsync<IEnumerable<TrainEntity>>("trains");
        }

        public async Task AddTrainAsync(TrainEntity train)
        {
            var response = await _http.PostAsJsonAsync("trains", train);
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }

        public async Task<TrainEntity> GetTrainAsync(Guid id)
        {
            var train = await _http.GetFromJsonAsync<TrainEntity>($"trains/{id}");
            return train;
        }

        public async Task UpdateTrainAsync(TrainEntity train)
        {
            var response = await _http.PutAsJsonAsync<TrainEntity>($"trains/{train.Id}", train);
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteTrainAsync(TrainEntity train)
        {
            var response = await _http.DeleteAsync($"trains/{train.Id}");
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }
    }
}
