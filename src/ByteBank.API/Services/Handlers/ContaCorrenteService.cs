// <copyright file="ContaCorrenteService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;
using ByteBank.API.Models;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Services.Interfaces;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Handlers
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository repository;

        public ContaCorrenteService(IMapper mapper, IContaCorrenteRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
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
    }
}