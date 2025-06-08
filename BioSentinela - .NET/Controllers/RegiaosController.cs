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
    public class RegiaosController : ControllerBase
    {
        private readonly IRepository<Regiao> _regiaoRepository;

        public RegiaosController(IRepository<Regiao> regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        // GET: api/Regiaos
        [HttpGet]
        public async Task<IEnumerable<Regiao>> GetRegiao()
        {
            return await _regiaoRepository.GetAllAsync();
        }

        // GET: api/Regiaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regiao>> GetRegiao(Guid id)
        {
            var regiao = await _regiaoRepository.GetByIdAssync(id);

            if (regiao == null)
            {
                return NotFound();
            }

            return regiao;
        }

        // PUT: api/Regiaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegiao(Guid id, RegiaoRequest request)
        {
            var regiao = await _regiaoRepository.GetByIdAssync(id);

            if (regiao == null)
                return NotFound();

            if (id != regiao.Id)
            {
                return BadRequest();
            }

            regiao.Update(request);
            _regiaoRepository.Update(regiao);            

            return NoContent();
        }

        // POST: api/Regiaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Regiao>> PostRegiao(RegiaoRequest regiaoRequest)
        {
            var regiao = new Regiao(regiaoRequest);

            await _regiaoRepository.AddAsync(regiao);

            return CreatedAtAction("GetRegiao", new { id = regiao.Id }, regiao);
        }

        // DELETE: api/Regiaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegiao(Guid id)
        {
            var regiao = await _regiaoRepository.GetByIdAssync(id);
            if (regiao == null)
            {
                return NotFound();
            }

            _regiaoRepository.Delete(regiao);

            return NoContent();
        }
    }
}
