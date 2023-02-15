using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Interfaces;
public interface IClienteService
{
    Task<ClienteViewModel> CriarClienteAsync(ClienteRequest clienteRequest);
}