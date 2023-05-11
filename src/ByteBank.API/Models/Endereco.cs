// <copyright file="Endereco.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ByteBank.API.Models
{
    public abstract class Endereco
    {
        public int Id { get; set; }

        required public string Logradouro { get; set; }

        public string? Complemento { get; set; }

        required public int Numero { get; set; }

        required public string Cep { get; set; }
        required public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        required public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

        public DateTime? ExcluidoEm { get; set; } = null;
    }
}