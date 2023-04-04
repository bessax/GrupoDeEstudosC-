
using ByteBank.API.Base;
using ByteBank.API.Models;

namespace ByteBank.API.Repository.Interface;
public interface IClienteRepository : IBaseRepository<Cliente>
{
    Task<Cliente> BuscaPorCPFAsync(string cpf);
}