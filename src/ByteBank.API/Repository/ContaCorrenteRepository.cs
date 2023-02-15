using ByteBank.API.Data;
using ByteBank.API.Enums;
using ByteBank.API.Interface;
using ByteBank.API.Models;

using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ByteBankContext context;

        public ContaCorrenteRepository(ByteBankContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Conta?> BuscaPorIdAsync(int id)
        {
            var query =
                from conta in this.context.Contas
                where conta.Id == id
                    && conta.Tipo == TipoConta.ContaCorrente
                    && conta.ExcluidoEm == null
                select conta;

            return await query.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Conta>> BuscaTodosAsync()
        {
            var query =
                from conta in this.context.Contas
                where conta.Tipo == TipoConta.ContaCorrente
                    && conta.ExcluidoEm == null
                select conta;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Conta>> BuscaTodosPaginadoAsync(int pagina, int tamanhoPagina)
        {
            var query =
                from conta in this.context.Contas
                where conta.Tipo == TipoConta.ContaCorrente
                    && conta.ExcluidoEm == null
                select conta;

            return await query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();
        }

        public async Task<IEnumerable<Conta>> BuscaPorCpfTitularAsync(string cpf)
        {
            var query =
                from cliente in this.context.Clientes
                where cliente.Cpf.Contains(cpf)
                from conta in cliente.Contas
                where conta.Tipo == TipoConta.ContaCorrente
                    && conta.ExcluidoEm == null
                select conta;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Conta>> BuscaPorNomeTitularAsync(string nome)
        {
            var query =
                from cliente in this.context.Clientes
                where cliente.Nome.Contains(nome)
                from conta in cliente.Contas
                where conta.Tipo == TipoConta.ContaCorrente
                    && conta.ExcluidoEm == null
                select conta;

            return await query.ToListAsync();
        }
    }
}