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
    public class AlertasController : ControllerBase
    {
        private readonly IRepository<Alerta> _alertsRepository;
        private readonly IRepository<Sensor> _sensorRepository;

        public AlertasController(IRepository<Alerta> alertsRepository, IRepository<Sensor> sensorRepository)
        {
            _alertsRepository = alertsRepository;
            _sensorRepository = sensorRepository;
        }

        // GET: api/Alertas
        [HttpGet]
        public async Task<IEnumerable<Alerta>> GetAlerta()
        {
            return await _alertsRepository.GetAllAsync();
        }

        // GET: api/Alertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(Guid id)
        {
            var alerta = await _alertsRepository.GetByIdAssync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

        // PUT: api/Alertas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlerta(Guid id, AlertaRequest request)
        {
            var alerta = await _alertsRepository.GetByIdAssync(id);

            if(alerta == null)
                return NotFound();

            if (id != alerta.Id)
            {
                return BadRequest();
            }

            alerta.Update(request);
            _alertsRepository.Update(alerta);
            
            return NoContent();
        }

        // POST: api/Alertas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Alerta>> PostAlerta(AlertaRequest alertaRequest)
        {
            var sensor = await _sensorRepository.GetByIdAssync(alertaRequest.SensorId);
            if (sensor == null)
                return BadRequest();

            var alerta = new Alerta(alertaRequest)
            {
                Created = "Sistema",
                DataCreated = DateTime.UtcNow,
                Updated = "Sistema",
                DataUpdated = DateTime.UtcNow
            };




            await _alertsRepository.AddAsync(alerta);

            return CreatedAtAction("GetAlerta", new { id = alerta.Id }, alerta);
        }

        // DELETE: api/Alertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlerta(Guid id)
        {
            var alerta = await _alertsRepository.GetByIdAssync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            _alertsRepository.Delete(alerta);

            return NoContent();
        }        
    }
}
