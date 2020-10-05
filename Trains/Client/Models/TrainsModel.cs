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

        private IEnumerable<Train> _trains;
        public IEnumerable<Train> Trains { get => _trains; }

        public TrainsModel(HttpClient http)
        {
            _http = http;
        }
        public async Task RetrieveTrainsAsync()
        {
            _trains = await _http.GetFromJsonAsync<IEnumerable<Train>>("trains");
        }

        public async Task AddTrainAsync(Train train)
        {
            var response = await _http.PostAsJsonAsync("trains", train);
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }

        public async Task<Train> GetTrainAsync(Guid id)
        {
            var train = await _http.GetFromJsonAsync<Train>($"trains/{id}");
            return train;
        }

        public async Task UpdateTrainAsync(Train train)
        {
            var response = await _http.PutAsJsonAsync<Train>($"trains/{train.Id}", train);
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteTrainAsync(Train train)
        {
            var response = await _http.DeleteAsync($"trains/{train.Id}");
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
        }
    }
}
