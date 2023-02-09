// <copyright file="AgenciaRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.ComponentModel.DataAnnotations;

namespace ByteBank.API.Request;
public class AgenciaRequest
{
    [Required(ErrorMessage = "O campo número da agência é obrigatório")]
    public required int NumeroAgencia { get; set; }
    [Required(ErrorMessage = "O campo nome da agência é obrigatório")]
    public required string NomeAgencia { get; set; }
    [Required(ErrorMessage = "O endereço é obrigatório")]
    public required EnderecoAgenciaRequest Endereco { get; set; }
}

public class EnderecoAgenciaRequest
{
    [Required(ErrorMessage = "O campo logradouro é obrigatório")]
    public required string Logradouro { get; set; }

    public string? Complemento { get; set; }
    [Required(ErrorMessage = "O campo número é obrigatório")]
    public required int Numero { get; set; }
    [Required(ErrorMessage = "O campo CEP é obrigatório")]
    public required string Cep { get; set; }

}