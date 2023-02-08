// <copyright file="ContaCorrenteProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;

using ByteBank.API.Dtos;
using ByteBank.API.Enums;
using ByteBank.API.Models;

namespace ByteBank.API.Profiles
{
    public class ContaCorrenteProfile : Profile
    {
        public ContaCorrenteProfile()
        {
            this.CreateMap<Conta, ContaCorrenteViewModel>();

            this.CreateMap<ContaCorrenteViewModel, Conta>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => TipoConta.ContaCorrente));
        }
    }
}