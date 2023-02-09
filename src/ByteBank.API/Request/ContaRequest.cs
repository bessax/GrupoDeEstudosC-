using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;

namespace ByteBank.API.Request;
public class ContaRequest
{
    [Required(ErrorMessage = "O número da conta é obrigatório")]
    [RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "O número da conta deve estar no formato 0000-0000-0000-0000")]
    public required string NumeroConta { get; set; }
    [Required(ErrorMessage = "Obrigatório saldo inicial")]
    public required double Saldo { get; set; }
    [Required(ErrorMessage = "A chave pix é obrigatória")]
    public required string ChavePix { get; set; }

    public required TipoConta Tipo { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "O id da agência deve ser maior que zero")]
    public required int AgenciaId { get; set; }
}