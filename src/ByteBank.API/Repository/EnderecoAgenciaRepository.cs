using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Interface;
using ByteBank.API.Models;

namespace ByteBank.API.Repository;

public class EnderecoAgenciaRepository : BaseRepository<EnderecoAgencia>, IEnderecoAgenciaRepository
{
    private readonly ByteBankContext context;

    public EnderecoAgenciaRepository(ByteBankContext context)
        : base(context)
    {
        this.context = context;
    }
}