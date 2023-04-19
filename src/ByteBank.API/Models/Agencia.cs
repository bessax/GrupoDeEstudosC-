// <copyright file="Agencia.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ByteBank.API.Models
{
    public class Agencia
    {
        public int Id { get; set; }
        required public int NumeroAgencia { get; set; }
        required public string NomeAgencia { get; set; }
        required public EnderecoAgencia Endereco { get; set; }
        required public DateTime CriadoEm { get; set; }

        required public DateTime AtualizadoEm { get; set; }

        public DateTime? ExcluidoEm { get; set; }
    }
}