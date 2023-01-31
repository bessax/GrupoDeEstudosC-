using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bytebank_API
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; } 
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
    }
}