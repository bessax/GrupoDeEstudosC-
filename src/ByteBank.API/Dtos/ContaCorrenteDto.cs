// <copyright file="ContaCorrenteDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

using ByteBank.API.Enums;

namespace ByteBank.API.Dtos
{
    public class ContaCorrenteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da conta é obrigatório")]
        [RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "O número da conta deve estar no formato 0000-0000-0000-0000")]
        required public string NumeroConta { get; set; }

        required public double Saldo { get; set; }

        [Required(ErrorMessage = "A chave pix é obrigatória")]
        required public string ChavePix { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O id da agência deve ser maior que zero")]
        required public int AgenciaId { get; set; }
    }
}