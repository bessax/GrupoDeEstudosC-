using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Interface;
using ByteBank.API.Models;

namespace ByteBank.API.Repository;

public class EnderecoAgenciaRepository : BaseRepository<EnderecoAgencia>, IEnderecoAgenciaRepository
{
    private ByteBankContext _context;
    public EnderecoAgenciaRepository(ByteBankContext context) : base(context)
    {
        _context = context;
    }
}
