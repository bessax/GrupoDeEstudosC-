// <copyright file="AgenciaProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Profiles
{
    public class AgenciaProfile : Profile
    {
        public AgenciaProfile()
        {
            this.CreateMap<AgenciaRequest, Agencia>().ForMember(a => a.Endereco, r => r.MapFrom(r => new EnderecoAgencia()
            {
                Logradouro = r.Endereco.Logradouro,
                Numero = r.Endereco.Numero,
                Complemento = r.Endereco.Complemento,
                Cep = r.Endereco.Cep
            }));

            this.CreateMap<Agencia, AgenciaViewModel>();
        }
    }
}