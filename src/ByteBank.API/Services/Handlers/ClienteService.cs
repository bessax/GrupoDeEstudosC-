using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Services.Handlers;

public class ClienteService : IClienteService
{
    private readonly IMapper mapper;
    private readonly IClienteRepository clienteRepository;
    private readonly IValidator<ClienteRequest> validator;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository, IValidator<ClienteRequest> validator)
    {
        this.mapper = mapper;
        this.clienteRepository = clienteRepository;
        this.validator = validator;
    }

    public async Task<ClienteViewModel> CriarClienteAsync(ClienteRequest clienteRequest)
    {
        await this.validator.ValidateAndThrowAsync(clienteRequest);

        Cliente cliente = this.mapper.Map<Cliente>(clienteRequest);

        foreach (var conta in cliente.Contas)
        {
            conta.CriadoEm = DateTime.Now;
            conta.AtualizadoEm = DateTime.Now;
        }

        await this.clienteRepository.CriarAsync(cliente);

        return this.mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<bool> AlteraClienteAsync(int id, ClienteRequest clienteRequest)
    {
        await this.validator.ValidateAndThrowAsync(clienteRequest);

        Cliente cliente = this.mapper.Map<Cliente>(clienteRequest);
        try
        {
            await this.clienteRepository.AlteraAsync(id, cliente);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await this.ClienteExists(cliente.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }

    private async Task<bool> ClienteExists(int id)
    {
        var clientes = await this.clienteRepository.BuscaTodosAsync();
        return (clientes?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}