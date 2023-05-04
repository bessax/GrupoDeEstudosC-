using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.Test.Builder
{
    internal class ClienteModelBuilder
    {
        private Random random = new Random();
        public Cliente Build()
        {
            return new Cliente()
            {
                Id = random.Next(1, 10),
                Nome = new Guid().ToString(),
                Cpf = new Guid().ToString(),
                Tipo = (TipoCliente)random.Next(0, 1),
                Endereco = new EnderecoCliente()
                {
                    Id = random.Next(1, 100),
                    Logradouro = new Guid().ToString(),
                    Numero = random.Next(1, 100000),
                    Cep = new Guid().ToString(),
                    Complemento = null,
                    CriadoEm = new DateTime(2021, 04, 23),
                    AtualizadoEm = new DateTime(2021, 04, 23),
                    ExcluidoEm = null
                },
                Contas = new Conta[]{
                    new Conta(){
                        Id = random.Next(1, 100),
                        NumeroConta = new Guid().ToString(),
                        Saldo = (double)random.Next(10,100000000),
                        ChavePix = new Guid().ToString(),
                        Tipo = (TipoConta)random.Next(0,1),
                        AgenciaId = random.Next(1, 100),
                        CriadoEm = new DateTime(2021, 04, 23),
                        AtualizadoEm = new DateTime(2021, 04, 23),
                        ExcluidoEm = null
                    }
                },
                CriadoEm = new DateTime(2021, 04, 23),
                AtualizadoEm = new DateTime(2021, 04, 23),
                ExcluidoEm = null
            };
        }

        public ClienteRequest BuildClienteRequest()
        {
            var random = new Random();

            var fourDigitsNumber = random.Next(0, 1000).ToString("D4");
            var threeDigitsNumber = random.Next(0, 1000).ToString("D3");
            var twoDigitsNumber = random.Next(0, 100).ToString("D2");
            return new ClienteRequest()
            {
                Nome = new string(Enumerable.Repeat(0, 30).Select(_ => (char)this.random.Next(33, 127)).ToArray()),
                Cpf = $"{threeDigitsNumber}.{threeDigitsNumber}.{threeDigitsNumber}-{twoDigitsNumber}",
                Tipo = (TipoCliente)random.Next(0, 1),
                Endereco = new EnderecoModelBuilder().BuildEnderecoRequest(),
                Contas = new ContaRequest[]{
                    new ContaModelBuilder().BuildContaRequest()
                }
            };
        }
    }
}