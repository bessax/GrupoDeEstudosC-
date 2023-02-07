// <copyright file="Conta.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Enums;

namespace ByteBank.API.Models
{
    public class Conta
    {
        public int Id { get; set; }

        required public string NumeroConta { get; set; }

        required public double Saldo { get; set; }

        required public string ChavePix { get; set; }

        required public TipoConta Tipo { get; set; }

        required public int AgenciaId { get; set; }

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