namespace bytebank_API.Models
{
    public abstract class Endereco
    {
        public int Id { get; set; }
        public required string Logradouro { get; set; }
        public string? Complemento { get; set; }
        public required int Numero { get; set; }
        public required string Cep { get; set; }
    }
}