using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet("paginado")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes(int pagina = 1, int tamanhoPagina = 10)
        {
            if (this.context.Clientes == null)
            {
                return this.NotFound();
            }

            return await this.context.Clientes
                .Include(c => c.Contas)
                .Include(c => c.Endereco)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .AsNoTracking()
                .ToListAsync(); ;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> GetCliente(int id)
        {
            var clienteView = await this.service.BuscaClientePorIdAsync(id);
            if (clienteView is null)
            {
                return this.NotFound();
            }

            return clienteView;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteRequest cliente)
        {
            bool result;
            try
            {
                result = await this.service.AlteraClienteAsync(id, cliente);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }

            if (!result) return NotFound();

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteRequest cliente)
        {
            ClienteViewModel clienteView;
            try
            {
                clienteView = await this.service.CriarClienteAsync(cliente);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

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