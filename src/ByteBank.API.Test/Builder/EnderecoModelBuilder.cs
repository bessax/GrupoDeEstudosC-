using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.Test.Builder
{
    internal class EnderecoModelBuilder
    {
        private Random random = new();
        public EnderecoRequest BuildEnderecoRequest()
        {
            var fiveDigitsNumber = random.Next(0, 1000).ToString("D5");
            var threeDigitsNumber = random.Next(0, 1000).ToString("D3");
            return new EnderecoRequest()
            {
                Logradouro = new string(Enumerable.Repeat(0, 20).Select(_ => (char)this.random.Next(33, 127)).ToArray()),
                Numero = random.Next(1, 100000),
                Cep = $"{fiveDigitsNumber}-{threeDigitsNumber}",
                Complemento = null,
            };
        }

        public EnderecoAgenciaRequest BuildEnderecoAgenciaRequest()
        {
            var fiveDigitsNumber = random.Next(0, 1000).ToString("D5");
            var threeDigitsNumber = random.Next(0, 1000).ToString("D3");
            return new EnderecoAgenciaRequest()
            {
                Logradouro = new string(Enumerable.Repeat(0, 20).Select(_ => (char)this.random.Next(33, 127)).ToArray()),
                Numero = random.Next(1, 100000),
                Cep = $"{fiveDigitsNumber}-{threeDigitsNumber}",
                Complemento = null,
            };
        }
        public EnderecoAgencia BuildEnderecoAgencia()
        {
            var fiveDigitsNumber = random.Next(0, 1000).ToString("D5");
            var threeDigitsNumber = random.Next(0, 1000).ToString("D3");
            return new EnderecoAgencia()
            {
                Id = this.random.Next(1, 1100),
                Logradouro = new string(Enumerable.Repeat(0, 20).Select(_ => (char)this.random.Next(33, 127)).ToArray()),
                Numero = random.Next(1, 100000),
                Cep = $"{fiveDigitsNumber}-{threeDigitsNumber}",
                Complemento = null,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow,
                ExcluidoEm = null
            };
        }
    }
}