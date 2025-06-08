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
    public class UsuariosController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuariosController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAssync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, UsuarioRequest request)
        {
            var usuario = await _usuarioRepository.GetByIdAssync(id);

            if (usuario == null)
                return NotFound();

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            usuario.Update(request);
            _usuarioRepository.Update(usuario);

           return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioRequest usuarioRequest)
        {
            var usuario = new Usuario(usuarioRequest);

            await _usuarioRepository.AddAsync(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAssync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Delete(usuario);

            return NoContent();
        }


    }
}
