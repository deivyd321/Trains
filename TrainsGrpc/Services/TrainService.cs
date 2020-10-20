using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            var train = new TrainEntity(request.Name, request.YearMade, (TrainColor) request.Color, request.LicensePlate, request.Company, request.HomeStation);

            _trainsStorageService.Trains.Add(train);

            return Task.FromResult(new GetTrainReply
            {
                Id = train.Id.ToString(),
                YearMade = train.YearMade,
                Name = train.Name,
                Color = (int) train.Color,
                HomeStation = train.HomeStation,
                Company = train.Company,
                IsRenovated = train.IsRenovated,
                LicensePlate = train.LicensePlate
            });
        }
    }
}
