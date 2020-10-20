using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trains.Server.Services;
using Trains.Shared;
using Trains.Shared.Enums;

namespace TrainsGrpc
{
    public class TrainService : Train.TrainBase
    {
        private readonly ILogger<TrainService> _logger;
        private readonly ITrainsStorageService _trainsStorageService;
        public TrainService(ILogger<TrainService> logger, ITrainsStorageService trainsStorageService)
        {
            _logger = logger;
            _trainsStorageService = trainsStorageService;
        }

        public override Task<GetTrainReply> AddTrain(AddTrainRequest request, ServerCallContext context)
        {
            var train = new TrainEntity(request.Name, request.YearMade, (TrainColor)request.Color, request.LicensePlate, request.Company, request.HomeStation);

            _trainsStorageService.Trains.Add(train);

            return Task.FromResult(new GetTrainReply
            {
                Id = train.Id.ToString(),
                YearMade = train.YearMade,
                Name = train.Name,
                Color = (int)train.Color,
                HomeStation = train.HomeStation,
                Company = train.Company,
                IsRenovated = train.IsRenovated,
                LicensePlate = train.LicensePlate
            });
        }

        public override async Task GetTrains(GetTrainsRequest request, IServerStreamWriter<GetTrainReply> responseStream, ServerCallContext context)
        {
            await Task.Delay(500);

            foreach (var train in _trainsStorageService.Trains)
            {
                await responseStream.WriteAsync(new GetTrainReply
                {
                    Id = train.Id.ToString(),
                    YearMade = train.YearMade,
                    Name = train.Name,
                    Color = (int)train.Color,
                    HomeStation = train.HomeStation,
                    Company = train.Company,
                    IsRenovated = train.IsRenovated,
                    LicensePlate = train.LicensePlate
                });

                await Task.Delay(1000);
            }
        }

        public override Task<GetTrainReply> EditTrain(EditTrainRequest request, ServerCallContext context)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == new Guid(request.Id));

            train.Edit(request.Name, (TrainColor)request.Color, request.LicensePlate, request.IsRenovated);

            return Task.FromResult(new GetTrainReply
            {
                Id = train.Id.ToString(),
                YearMade = train.YearMade,
                Name = train.Name,
                Color = (int)train.Color,
                HomeStation = train.HomeStation,
                Company = train.Company,
                IsRenovated = train.IsRenovated,
                LicensePlate = train.LicensePlate
            });
        }

        public override Task<EmptyReply> DeleteTrain(DeleteTrainRequest request, ServerCallContext context)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == new Guid(request.Id));

            _trainsStorageService.Trains.Remove(train);

            return Task.FromResult(new EmptyReply());
        }
    }
}
