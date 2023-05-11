using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.Test.Builder
{
    internal class ContaModelBuilder
    {
        private Random random = new Random();

        public ContaRequest BuildContaRequest()
        {
            var fourDigitsNumber = random.Next(0, 1000).ToString("D4");
            var threeDigitsNumber = random.Next(0, 1000).ToString("D3");
            var twoDigitsNumber = random.Next(0, 100).ToString("D2");
            return new ContaRequest()
            {
                AgenciaId = this.random.Next(1, 100),
                ChavePix = $"{threeDigitsNumber}.{threeDigitsNumber}.{threeDigitsNumber}-{twoDigitsNumber}",
                NumeroConta = $"{fourDigitsNumber}-{fourDigitsNumber}-{fourDigitsNumber}-{fourDigitsNumber}",
                Saldo = (double)random.Next(10, 1000000),
                Tipo = (TipoConta)this.random.Next(0, 1)
            };
        }

        public Conta BuildConta()
        {
            return new Conta()
            {
                AgenciaId = this.random.Next(1, 1000),
                ChavePix = new Guid().ToString(),
                NumeroConta = new Guid().ToString(),
                Saldo = (double)this.random.Next(10, 100000),
                Tipo = (TipoConta)0
            };
        }
    }
}