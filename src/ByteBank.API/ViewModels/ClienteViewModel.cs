using ByteBank.API.Enums;
using ByteBank.API.Models;

namespace ByteBank.API.ViewModels;
public class ClienteViewModel
{
    public int Id { get; set; }

    required public string Cpf { get; set; }

    required public string Nome { get; set; }

    required public TipoCliente Tipo { get; set; }

    required public ICollection<Conta> Contas { get; set; }

    required public EnderecoCliente Endereco { get; set; }
    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }
}