using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bytebank_API.Models;
using bytebank_API.Repository;
using bytebank_API.Services;

namespace bytebank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly IAgenciasService _service;

        public AgenciasController(IAgenciasService service)
        {
            _service = service;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
            var agencias = await _service.BuscaAgenciasAsync();

            if (agencias == null)
            {
                return NotFound();
            }
            return agencias;
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            var agencia = await _service.BuscaAgenciaPorIdAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }
            return agencia;
        }

        // PUT: api/Agencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(int id, Agencia agencia)
        {
            if (id != agencia.Id)
            {
                return BadRequest();
            }

            return await _service.AlteraAgenciaAsync(agencia) ? NoContent() : NotFound();
        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            if (await _service.BuscaAgenciasAsync() == null)
            {
                return Problem("Entity set 'ByteBankContext.Agencias'  is null.");
            }

            var agenciaCriada = await _service.CriaAgenciaAsync(agencia);

            return CreatedAtAction("GetAgencia", new { id = agenciaCriada.Id }, agenciaCriada);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {

            return await _service.DeletaAgenciaAsync(id) ? NoContent() : NotFound();
        }

    }
}
