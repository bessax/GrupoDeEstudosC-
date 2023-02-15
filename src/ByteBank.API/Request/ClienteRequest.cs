using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;
using ByteBank.API.Models;

namespace ByteBank.API.Request;
public class ClienteRequest
{
    [Required(ErrorMessage = "CPF é obrigatório")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Informe o CPF no formato 000.000.000-00")]
    required public string Cpf { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    required public string Nome { get; set; }

    [Required(ErrorMessage = "Tipo cliente é obrigatório")]
    [Range(0, 1, ErrorMessage = "Expecifique 0 - PessoaFísica, 1 - Cnpj")]
    required public TipoCliente Tipo { get; set; }

    [Required(ErrorMessage = "Obrigatório dados da conta")]
    required public ICollection<ContaRequest> Contas { get; set; }

    [Required(ErrorMessage = "Endereço é obrigatório")]
    required public EnderecoRequest Endereco { get; set; }
}