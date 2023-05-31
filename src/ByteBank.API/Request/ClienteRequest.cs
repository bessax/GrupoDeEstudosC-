using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;
using ByteBank.API.Models;

namespace ByteBank.API.Request;
public class ClienteRequest
{
    required public string Cpf { get; set; }
    required public string Nome { get; set; }
    required public TipoCliente Tipo { get; set; }
    required public ICollection<ContaRequest> Contas { get; set; }
    required public EnderecoRequest Endereco { get; set; }
}