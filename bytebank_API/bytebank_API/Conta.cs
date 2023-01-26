using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_API
{
    public class Conta
    {
        public int IdConta { get; set; }
        public string NumeroConta { get; set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; set; }
        public Agencia Agencia { get; set; }
        public string ChavePix { get; set; }
        public TipoConta Tipo { get; set; }

        public void Sacar()
        {

        }
        public void Transferir()
        {

        }
        public void Depositar()
        {

        }
        public void Rendimento()
        {

        }

    }
}
