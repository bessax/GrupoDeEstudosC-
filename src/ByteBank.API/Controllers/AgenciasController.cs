// <copyright file="AgenciasController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;
using ByteBank.API.Repository;
using ByteBank.API.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
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
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
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
        public async Task<IActionResult> PutAgencia(int id, Agencia agencia)
        {
            if (id != agencia.Id)
            {
                return this.BadRequest();
            }

            return await this.service.AlteraAgenciaAsync(agencia) ? this.NoContent() : this.NotFound();
        }

        // POST: api/Agencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            if (await this.service.BuscaAgenciasAsync() == null)
            {
                return this.Problem("Entity set 'ByteBankContext.Agencias'  is null.");
            }

            var agenciaCriada = await this.service.CriaAgenciaAsync(agencia);

            return this.CreatedAtAction("GetAgencia", new { id = agenciaCriada.Id }, agenciaCriada);
        }

        // DELETE: api/Agencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            return await this.service.DeletaAgenciaAsync(id) ? this.NoContent() : this.NotFound();
        }
    }
}