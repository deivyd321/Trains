using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Server.Services;
using Trains.Shared;
using Trains.Shared.Enums;

namespace Trains.Server.Controllers
{
    [Route("trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        TrainsStorageService _trainsStorageService;

        public TrainController(TrainsStorageService trainsStorageService)
        {
            _trainsStorageService = trainsStorageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Train>> Get()
        {
            return Ok(_trainsStorageService.Trains.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Train> Get(Guid id)
        {
            var train = _trainsStorageService.Trains.First(x=>x.Id == id);
            return Ok(train);
        }

        [HttpPost]
        public ActionResult<Train> Post([FromBody] Train value)
        {
            // TODO add is valid
            _trainsStorageService.Trains.Add(value);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public void Put([FromRoute] Guid id, [FromBody] Train value)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == id);
            _trainsStorageService.Trains.Remove(train);
            _trainsStorageService.Trains.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == id);
        }
    }
}
