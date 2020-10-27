using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trains.Server.Repositories;
using Trains.Server.Services;
using Trains.Shared;

namespace Trains.Server.Controllers
{
    [Route("trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainRepository _trainRepository;

        public TrainController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainEntity>>> Get()
        {
            var trains = await _trainRepository.GetAllAsync();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainEntity>> Get(Guid id)
        {
            var train = await _trainRepository.GetAsync(id);
            return Ok(train);
        }

        [HttpPost]
        public async Task<ActionResult<TrainEntity>> Post([FromBody] TrainEntity value)
        {
            await _trainRepository.InsertAsync(value);
            await _trainRepository.SaveAsync();
            return CreatedAtAction(nameof(Post), value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] TrainEntity value)
        {
           // var train = await _trainRepository.GetAsync(id);

            _trainRepository.Update(value);
            await _trainRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var train = await _trainRepository.GetAsync(id);
            _trainRepository.Delete(train);
            await _trainRepository.SaveAsync();
            return NoContent();
        }
    }
}
