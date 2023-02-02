using bytebank_API.Enums;

namespace bytebank_API.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public required string NumeroConta { get; set; }
        public required double Saldo { get; set; }
        public required string ChavePix { get; set; }
        public required TipoConta Tipo { get; set; }
        public required int AgenciaId { get; set; }

        public void Sacar()
        {
            throw new NotImplementedException();
        }

        public void Transferir()
        {
            throw new NotImplementedException();
        }

        public void Depositar()
        {
            throw new NotImplementedException();
        }

        public void Rendimento()
        {
            throw new NotImplementedException();
        }
    }
}
