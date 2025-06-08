using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET___BioSentinela.Domain.Entities;
using NET___BioSentinela.Infrastructure.Context;
using NET___BioSentinela.Infrastructure.DTO.Request;
using NET___BioSentinela.Infrastructure.Persistence.Repositories;

namespace BioSentinela___.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
       private readonly IRepository<Sensor> _sensorRepository;
       private readonly IRepository<Regiao> _regiaoRepository;

        public SensorsController(IRepository<Sensor> sensorRepository, IRepository<Regiao> regiaoRepository)
        {
            _sensorRepository = sensorRepository;
            _regiaoRepository = regiaoRepository;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<IEnumerable<Sensor>> GetSensors()
        {
            return await _sensorRepository.GetAllAsync();
        }

        // GET: api/Sensors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(Guid id)
        {
            var sensor = await _sensorRepository.GetByIdAssync(id);

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        // PUT: api/Sensors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(Guid id, SensorRequest request)
        {
            var sensor = await _sensorRepository.GetByIdAssync(id);

            if (sensor == null)
            {
                return NotFound();
            }

            if (id != sensor.Id)
            {
                return BadRequest();
            }

            sensor.Update(request); 
            _sensorRepository.Update(sensor);

           

            return NoContent();
        }

        // POST: api/Sensors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Sensor>> PostSensor(SensorRequest sensorRequest)
        {
            var regiao = await _regiaoRepository.GetByIdAssync(sensorRequest.RegiaoId);
            if (regiao == null)
                return BadRequest();

            var sensor = new Sensor(sensorRequest)
            {
                Created = "Sistema",
                DataCreated = DateTime.UtcNow,
                Updated = "Sitema",
                DataUpdated = DateTime.UtcNow,
            };

            await _sensorRepository.AddAsync(sensor);

            return CreatedAtAction("GetSensor", new { id = sensor.Id }, sensor);
        }

        // DELETE: api/Sensors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(Guid id)
        {
            var sensor = await _sensorRepository.GetByIdAssync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            _sensorRepository.Delete(sensor);

            return NoContent();
        }
    }
}
