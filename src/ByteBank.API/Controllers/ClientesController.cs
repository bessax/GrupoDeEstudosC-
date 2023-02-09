using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Services;
using ByteBank.API.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ByteBankContext context;
        private readonly IClienteService service;

        public ClientesController(ByteBankContext context, IClienteService service)
        {
            this.context = context;
            this.service = service;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            if (this.context.Clientes == null)
            {
                return this.NotFound();
            }

            return await this.context.Clientes
                .Include(c => c.Contas)
                .Include(c => c.Endereco)
                .ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            if (this.context.Clientes == null)
            {
                return this.NotFound();
            }

            var cliente = await this.context.Clientes
                .Include(c => c.Contas)
                .Include(c => c.Endereco)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return this.NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return this.BadRequest();
            }

            this.context.Clientes.Update(cliente);

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ClienteExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteRequest cliente)
        {
            if (this.context.Clientes == null)
            {
                return this.Problem("Entity set 'ByteBankContext.Clientes'  is null.");
            }

            ClienteViewModel clienteView = await this.service.CriarClienteAsync(cliente);

            return this.CreatedAtAction("GetCliente", new { id = clienteView.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (this.context.Clientes == null)
            {
                return this.NotFound();
            }

            var cliente = await this.context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return this.NotFound();
            }

            this.context.Clientes.Remove(cliente);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (this.context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}