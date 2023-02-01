using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_API
{
    public class Agencia
    {
        public int IdAgencia { get; set; }
        public int NumeroAgencia { get; set; }
        public string? NomeAgencia { get; set; }
        public EnderecoAgencia? EnderecoAgencia { get; set; }
    }
}