using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Handlers;

public class ClienteService : IClienteService
{
    private readonly IMapper mapper;
    private readonly IClienteRepository clienteRepository;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
    {
        this.mapper = mapper;
        this.clienteRepository = clienteRepository;
    }

    public async Task<ClienteViewModel> CriarClienteAsync(ClienteRequest clienteRequest)
    {
        Cliente cliente = this.mapper.Map<Cliente>(clienteRequest);

        foreach (var conta in cliente.Contas)
        {
            conta.CriadoEm = DateTime.Now;
            conta.AtualizadoEm = DateTime.Now;
        }

        await this.clienteRepository.CriarAsync(cliente);

        return this.mapper.Map<ClienteViewModel>(cliente);
    }
}