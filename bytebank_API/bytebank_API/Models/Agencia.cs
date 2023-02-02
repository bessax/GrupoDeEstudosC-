namespace bytebank_API.Models
{
    public class Agencia
    {
        public int Id { get; set; }
        public required int NumeroAgencia { get; set; }
        public required string NomeAgencia { get; set; }

        public required EnderecoAgencia Endereco { get; set; }
    }
}
