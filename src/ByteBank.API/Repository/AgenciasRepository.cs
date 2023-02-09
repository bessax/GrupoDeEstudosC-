using ByteBank.API.Data;
using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Repository
{
    public class AgenciasRepository : IRepository<Agencia>
    {
        private readonly ByteBankContext context;

        public AgenciasRepository(ByteBankContext context)
        {
            this.context = context;
        }

        public async Task<List<Agencia>> BuscaTodosAsync()
        {
            return await this.context.Agencias.Include(a => a.Endereco)
                .ToListAsync();
        }

        public async Task<Agencia> BuscaPorIdAsync(int id)
        {
            return await this.context.Agencias.Include(a => a.Endereco).FirstAsync(a => a.Id == id);
        }

        public async Task AlteraAsync(Agencia agencia)
        {
            this.context.Agencias.Update(agencia);
            await this.context.SaveChangesAsync();
        }

        public async Task CriarAsync(Agencia agencia)
        {
            this.context.Agencias.Add(agencia);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletaAsync(Agencia agencia)
        {
            this.context.Agencias.Remove(agencia);
            await this.context.SaveChangesAsync();
        }
    }
}