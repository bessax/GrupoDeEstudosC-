using bytebank_API.Enums;

namespace bytebank_API.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public required string Cpf { get; set; }

        public required string Nome { get; set; }

        public required TipoCliente Tipo { get; set; }

        public required ICollection<Conta> Contas { get; set; }

        public required EnderecoCliente Endereco { get; set; }
    }
}
