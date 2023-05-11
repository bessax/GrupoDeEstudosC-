using ByteBank.API.Enums;

namespace ByteBank.API.ViewModels
{
    public class ContaCorrenteViewModel
    {
        public int Id { get; set; }
        required public string NumeroConta { get; set; }

        required public double Saldo { get; set; }

        required public string ChavePix { get; set; }

        required public TipoConta Tipo { get; set; }
        required public int AgenciaId { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }
    }
}