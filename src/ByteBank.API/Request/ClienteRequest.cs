using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;
using ByteBank.API.Models;

namespace ByteBank.API.Request;
public class ClienteRequest
{
    [Required(ErrorMessage = "CPF é obrigatório")]
    public required string Cpf { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    public required string Nome { get; set; }
    [Required(ErrorMessage = "Tipo de conta é obrigatório")]
    public required TipoCliente Tipo { get; set; }
    [Required(ErrorMessage = "Obrigatório dados da conta")]
    public required ICollection<Conta> Contas { get; set; }
    [Required(ErrorMessage = "Endereço é obrigatório")]
    public required EnderecoCliente Endereco { get; set; }
}