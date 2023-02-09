// <copyright file="AgenciaRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace ByteBank.API.Request;
public class AgenciaRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "O número da agência deve ser maior que zero")]
    public required int NumeroAgencia { get; set; }

    [Required(ErrorMessage = "O campo nome da agência é obrigatório")]
    [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public required string NomeAgencia { get; set; }
    [Required(ErrorMessage = "O endereço é obrigatório")]
    public required EnderecoRequest Endereco { get; set; }
}