using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Server.Services;
using Trains.Shared;

namespace Trains.Server.Controllers
{
    [Route("trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        ITrainsStorageService _trainsStorageService;

        public TrainController(ITrainsStorageService trainsStorageService)
        {
            _trainsStorageService = trainsStorageService;
        }

        [HttpGet]
        public ActionResult<List<TrainEntity>> Get()
        {
            return Ok(_trainsStorageService.Trains.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<TrainEntity> Get(Guid id)
        {
            var train = _trainsStorageService.Trains.First(x=>x.Id == id);
            return Ok(train);
        }

        [HttpPost]
        public ActionResult<TrainEntity> Post([FromBody] TrainEntity value)
        {
            // TODO add is valid
            _trainsStorageService.Trains.Add(value);
            return CreatedAtAction(nameof(Post), value);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] TrainEntity value)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == id);
            _trainsStorageService.Trains.Remove(train);
            _trainsStorageService.Trains.Add(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var train = _trainsStorageService.Trains.First(x => x.Id == id);
            _trainsStorageService.Trains.Remove(train);
            return NoContent();
        }
    }
}
