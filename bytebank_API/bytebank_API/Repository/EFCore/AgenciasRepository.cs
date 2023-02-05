using bytebank_API.Data;
using bytebank_API.Models;
using Microsoft.EntityFrameworkCore;

namespace bytebank_API.Repository.EFCore
{

    public class AgenciasRepository : IAgenciasRepository
    {
        private readonly ByteBankContext _context;

        public AgenciasRepository(ByteBankContext context)
        {
            _context = context;
        }

        public async Task<List<Agencia>> BuscaAgenciasAsync()
        {
            return await _context.Agencias.Include(a => a.Endereco)
                .ToListAsync(); ;
        }

        public async Task<Agencia> BuscaAgenciaPorIdAsync(int id)
        {
            return await _context.Agencias.Include(a => a.Endereco).FirstAsync(a => a.Id == id);
        }

        public async Task AlteraAgenciaAsync(Agencia agencia)
        {
            _context.Entry(agencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task CriarAgenciaAsync(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeletaAgenciaAsync(Agencia agencia)
        {
            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();
        }
    }
}