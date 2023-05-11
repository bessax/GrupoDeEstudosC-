using ByteBank.API.Models;
namespace ByteBank.API.ViewModels;

public class AgenciaViewModel
{
    required public int Id { get; set; }

    required public int NumeroAgencia { get; set; }

    required public string NomeAgencia { get; set; }

    required public EnderecoAgencia Endereco { get; set; }
}