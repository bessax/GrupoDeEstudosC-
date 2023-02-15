using ByteBank.API.Models;
namespace ByteBank.API.ViewModels;

public class EnderecoAgenciaViewModel
{
    required public string Logradouro { get; set; }
    public string? Complemento { get; set; }
    required public int Numero { get; set; }
    required public string Cep { get; set; }
}