using ByteBank.API.Models;

namespace ByteBank.API.Test.Builder
{
    internal class ClienteModelBuilder
    {
        public Cliente Build()
        {
            return new Cliente()
            {
                Id = 0,
                Nome = "João",
                Cpf = "123.654.897-44",
                Tipo = 0,
                Endereco = new EnderecoCliente()
                {
                    Id = 101,
                    Logradouro = "Rua Manoel",
                    Numero = 888,
                    Cep = "88899-000",
                    Complemento = " ",
                    CriadoEm = new DateTime(2021, 04, 23),
                    AtualizadoEm = new DateTime(2021, 04, 23),
                    ExcluidoEm = null
                },
                Contas = new Conta[]{
                    new Conta(){
                        Id = 23,
                        NumeroConta = "3219-4545-6554-9635",
                        Saldo = 456879126.20,
                        ChavePix = "joao@email.com",
                        Tipo = 0,
                        AgenciaId = 2,
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
    }
}