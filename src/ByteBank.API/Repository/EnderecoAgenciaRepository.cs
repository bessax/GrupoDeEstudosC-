using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;

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