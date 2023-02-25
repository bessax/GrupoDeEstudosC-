using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ByteBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly IAgenciasService service;

        public AgenciasController(IAgenciasService service)
        {
            this.service = service;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenciaViewModel>>> GetAgencias()
        {
            var agencias = await this.service.BuscaAgenciasAsync();

            if (agencias == null)
            {
                return this.NotFound();
            }

            return agencias;
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenciaViewModel>> GetAgencia(int id)
        {
            var agencia = await this.service.BuscaAgenciaPorIdAsync(id);

            if (agencia == null)
            {
                return this.NotFound();
            }

            return agencia;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(int id, AgenciaRequest agencia)
        {
            try
            {
                return await this.service.AlteraAgenciaAsync(agencia) ? this.NoContent() : this.NotFound();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgenciaViewModel>> PostAgencia(AgenciaRequest agencia)
        {
            try
            {
                var agenciaCriada = await this.service.CriaAgenciaAsync(agencia);

                return this.CreatedAtAction("GetAgencia", new { id = agenciaCriada.Id }, agenciaCriada);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            return await this.service.DeletaAgenciaAsync(id) ? this.NoContent() : this.NotFound();
        }

        [HttpGet("paginado")]
        public async Task<ActionResult<AgenciaViewModel>> GetAgenciasPaginadasAsync(int pagina = 1, int tamanhoPagina = 10)
        {
            var agencias = await service.AgenciaPaginadoAsync(pagina, tamanhoPagina);
            if (agencias == null)
            {
                return this.Problem("Não existe dados a serem retornados.");
            }
            return this.Ok(agencias);
        }
    }
}