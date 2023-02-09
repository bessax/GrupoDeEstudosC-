
using ByteBank.API.Models;
namespace ByteBank.API.ViewModels;
public class AgenciaViewModel
{
    public required int Id { get; set; }

    public required int NumeroAgencia { get; set; }

    public required string NomeAgencia { get; set; }

    public required EnderecoAgencia Endereco { get; set; }
}