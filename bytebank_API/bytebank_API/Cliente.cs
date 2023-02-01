using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_API
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public TipoCliente Tipo { get; set; }
        public EnderecoCliente? EnderecoCliente { get; set; }

    }
}