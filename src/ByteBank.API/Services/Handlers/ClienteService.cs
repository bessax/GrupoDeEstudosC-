using AutoMapper;

using ByteBank.API.Interface;
using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Handlers;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
    }

    public async Task<ClienteViewModel> CriarClienteAsync(ClienteRequest clienteRequest)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteRequest);

        foreach (var conta in cliente.Contas)
        {
            conta.CriadoEm = DateTime.Now;
            conta.AtualizadoEm = DateTime.Now;
        }

        await _clienteRepository.CriarAsync(cliente);

        return _mapper.Map<ClienteViewModel>(cliente);
    }
}