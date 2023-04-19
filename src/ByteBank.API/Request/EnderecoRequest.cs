using System.ComponentModel.DataAnnotations;

namespace ByteBank.API.Request;

public class EnderecoRequest
{
    required public string Logradouro { get; set; }

    public string? Complemento { get; set; }

    required public int Numero { get; set; }

    required public string Cep { get; set; }
    public DateTime CriadoEm { get; internal set; }
    public DateTime AtualizadoEm { get; internal set; }

}