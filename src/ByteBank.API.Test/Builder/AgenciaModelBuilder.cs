using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.Test.Builder
{
    internal class AgenciaModelBuilder
    {
        public Agencia Build()
        {
            Random rd = new Random();
            return new Agencia
            {
                Id = rd.Next(1, 9999),
                NomeAgencia = Guid.NewGuid().ToString().Substring(0, 10),
                NumeroAgencia = rd.Next(1, 9999),
                Endereco = new EnderecoAgencia
                {
                    Id = rd.Next(1, 9999),
                    Numero = rd.Next(1, 9999),
                    Cep = "00000-000",
                    Logradouro = Guid.NewGuid().ToString().Substring(0, 20),
                    CriadoEm = DateTime.Now,
                    AtualizadoEm = DateTime.Now
                },
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };
        }


    }
}
