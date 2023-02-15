using System.ComponentModel.DataAnnotations;

namespace ByteBank.API.Request;
public class AgenciaRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "O número da agência deve ser maior que zero")]
    required public int NumeroAgencia { get; set; }

    [Required(ErrorMessage = "O campo nome da agência é obrigatório")]
    [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    required public string NomeAgencia { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    required public EnderecoRequest Endereco { get; set; }
}