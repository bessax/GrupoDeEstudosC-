using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bytebank_API.Data;
using bytebank_API.Models;

namespace bytebank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly ByteBankContext _context;

        public AgenciasController(ByteBankContext context)
        {
            _context = context;
        }

        // GET: api/Agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
            if (_context.Agencias == null)
            {
                return NotFound();
            }
            return await _context.Agencias.ToListAsync();
        }

        // GET: api/Agencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            if (_context.Agencias == null)
            {
                return NotFound();
            }
            var agencia = await _context.Agencias.FindAsync(id);

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

            _context.Entry(agencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciaExists(id))
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
            if (_context.Agencias == null)
            {
                return Problem("Entity set 'ByteBankContext.Agencias'  is null.");
            }
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgencia", new { id = agencia.Id }, agencia);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            if (_context.Agencias == null)
            {
                return NotFound();
            }
            var agencia = await _context.Agencias.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenciaExists(int id)
        {
            return (_context.Agencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
