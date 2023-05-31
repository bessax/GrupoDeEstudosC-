using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Repository;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    private readonly ByteBankContext context;

    public ClienteRepository(ByteBankContext context)
        : base(context)
    {
        this.context = context;
    }
    public override async Task<Cliente?> BuscaPorIdAsync(int id)
    {
        return await this.context.Clientes
                .Include(c => c.Contas)
                .Include(c => c.Endereco)
                .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> BuscaPorCPFAsync(string cpf)
    {
        return await this.context.Clientes
                .Include(c => c.Contas)
                .Include(c => c.Endereco)
                .SingleOrDefaultAsync(c => c.Cpf == cpf);
    }
}