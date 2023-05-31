using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Repository
{
    public class AgenciasRepository : BaseRepository<Agencia>, IAgenciaRepository
    {
        private readonly ByteBankContext context;

        public AgenciasRepository(ByteBankContext context)
            : base(context)
        {
            this.context = context;
        }

        public override async Task<List<Agencia>> BuscaTodosAsync()
        {
            return await this.context.Agencias.Include(a => a.Endereco)
                .ToListAsync();
        }

        public override async Task<Agencia?> BuscaPorIdAsync(int id)
        {
            return await this.context.Agencias.Include(a => a.Endereco).FirstAsync(a => a.Id == id);
        }

    }
}