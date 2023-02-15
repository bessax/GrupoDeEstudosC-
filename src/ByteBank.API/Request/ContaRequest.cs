using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;

namespace ByteBank.API.Request;
public class ContaRequest
{
    [Required(ErrorMessage = "O número da conta é obrigatório")]
    [RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "O número da conta deve estar no formato 0000-0000-0000-0000")]
    required public string NumeroConta { get; set; }

    [Required(ErrorMessage = "Obrigatório saldo inicial")]
    required public double Saldo { get; set; }

    [Required(ErrorMessage = "A chave pix é obrigatória")]
    required public string ChavePix { get; set; }

    [Required(ErrorMessage = "Tipo de conta é obrigatório")]
    [Range(0, 1, ErrorMessage = "Expecifique 0 - Conta Corrente, 1 - Conta Poupança")]
    required public TipoConta Tipo { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O id da agência deve ser maior que zero")]
    required public int AgenciaId { get; set; }
}