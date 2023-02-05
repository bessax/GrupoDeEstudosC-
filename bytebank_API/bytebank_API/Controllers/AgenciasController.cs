using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bytebank_API.Data;
using bytebank_API.Models;
using bytebank_API.Repository;

namespace bytebank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly IAgenciasRepository _repository;

        public AgenciasController(IAgenciasRepository context)
        {
            _repository = context;
        }


        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
            if (await _repository.BuscaAgenciasAsync() == null)
            {
                return NotFound();
            }
            return await _repository.BuscaAgenciasAsync();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            if (await _repository.BuscaAgenciasAsync() == null)
            {
                return NotFound();
            }
            var agencia = await _repository.BuscaAgenciaPorIdAsync(id);

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

            try
            {
                await _repository.AlteraAgenciaAsync(agencia);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AgenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            if (await _repository.BuscaAgenciasAsync() == null)
            {
                return Problem("Entity set 'ByteBankContext.Agencias'  is null.");
            }

            await _repository.CriarAgenciaAsync(agencia);

            return CreatedAtAction("GetAgencia", new { id = agencia.Id }, agencia);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            if (await _repository.BuscaAgenciasAsync() == null)
            {
                return NotFound();
            }
            var agencia = await _repository.BuscaAgenciaPorIdAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            await _repository.DeletaAgenciaAsync(agencia);

            return NoContent();
        }

        private async Task<bool> AgenciaExists(int id)
        {
            var agencias = await _repository.BuscaAgenciasAsync();
            return (agencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
