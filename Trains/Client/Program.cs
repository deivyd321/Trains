using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Trains.Client.Models;
using Trains.Client.ViewModels;

namespace Trains.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<ITrainsModel, TrainsModel>();
            builder.Services.AddScoped<ITrainViewModel, TrainsViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
