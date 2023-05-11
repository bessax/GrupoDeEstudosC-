using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;

namespace ByteBank.API.Request;
public class ContaRequest
{
    required public string NumeroConta { get; set; }

    required public double Saldo { get; set; }

    required public string ChavePix { get; set; }

    required public TipoConta Tipo { get; set; }

    required public int AgenciaId { get; set; }
}