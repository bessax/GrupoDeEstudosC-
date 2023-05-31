using ByteBank.API.Models;
namespace ByteBank.API.ViewModels;

public class EnderecoAgenciaViewModel
{
    required public int Id { get; set; }
    required public string Logradouro { get; set; }
    public string? Complemento { get; set; }
    required public int Numero { get; set; }
    required public string Cep { get; set; }
    public DateTime CriadoEm { get; set; }

    public DateTime AtualizadoEm { get; set; }
}