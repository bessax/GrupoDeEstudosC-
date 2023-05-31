// <copyright file="ContaCorrenteService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;
using FluentValidation;

namespace ByteBank.API.Services.Handlers
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository repository;
        private readonly IClienteRepository clienteRepository;
        private readonly IValidator<ContaRequest> validator;

        public ContaCorrenteService(IMapper mapper, IContaCorrenteRepository repository, IClienteRepository clienteRepository, IValidator<ContaRequest> validator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.clienteRepository = clienteRepository;
            this.validator = validator;
        }

        public async Task<ContaCorrenteViewModel?> BuscaContaCorrentePorIdAsync(int id)
        {
            var contaCorrente = await this.repository.BuscaPorIdAsync(id);
            return this.mapper.Map<ContaCorrenteViewModel>(contaCorrente);
        }

        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesAsync()
        {
            var contasCorrentes = await this.repository.BuscaTodosAsync();
            return this.mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var contasCorrentes = await this.repository.BuscaTodosPaginadoAsync(pagina, tamanhoPagina);
            return this.mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorCpfTitularAsync(string cpf)
        {
            var contasCorrentes = await this.repository.BuscaPorCpfTitularAsync(cpf);
            return this.mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);
        }

        public async Task<IEnumerable<ContaCorrenteViewModel>> BuscaContasCorrentesPorNomeTitularAsync(string nome)
        {
            var contasCorrentes = await this.repository.BuscaPorNomeTitularAsync(nome);
            return this.mapper.Map<IEnumerable<ContaCorrenteViewModel>>(contasCorrentes);
        }

        public async Task<ContaCorrenteViewModel?> CriaContaAsync(int id, ContaRequest contaRequest)
        {
            await this.validator.ValidateAndThrowAsync(contaRequest);

            var cliente = await this.clienteRepository.BuscaPorIdAsync(id);
            if (cliente is null) return null;

            Conta conta = this.mapper.Map<Conta>(contaRequest);
            conta.CriadoEm = DateTime.Now;
            conta.AtualizadoEm = DateTime.Now;

            cliente.Contas.Add(conta);

            await this.clienteRepository.AlteraAsync(id, cliente);

            return this.mapper.Map<ContaCorrenteViewModel>(conta);

        }
    }
}