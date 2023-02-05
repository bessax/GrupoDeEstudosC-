using bytebank_API.Data;
using bytebank_API.Models;
using Microsoft.EntityFrameworkCore;

namespace bytebank_API.Repository.EFCore
{

    public class AgenciasRepository : IRepository<Agencia>
    {
        private readonly ByteBankContext _context;

        public AgenciasRepository(ByteBankContext context)
        {
            _context = context;
        }

        public async Task<List<Agencia>> BuscaTodosAsync()
        {
            return await _context.Agencias.Include(a => a.Endereco)
                .ToListAsync(); ;
        }

        public async Task<Agencia> BuscaPorIdAsync(int id)
        {
            return await _context.Agencias.Include(a => a.Endereco).FirstAsync(a => a.Id == id);
        }

        public async Task AlteraAsync(Agencia agencia)
        {
            // _context.Entry(agencia).State = EntityState.Modified;
            _context.Agencias.Update(agencia);
            await _context.SaveChangesAsync();
        }

        public async Task CriarAsync(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeletaAsync(Agencia agencia)
        {
            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();
        }
    }
}