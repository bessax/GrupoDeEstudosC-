// <copyright file="ContaCorrenteProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using AutoMapper;

using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles
{
    public class ContaCorrenteProfile : Profile
    {
        public ContaCorrenteProfile()
        {
            CreateMap<Conta, ContaCorrenteViewModel>();

            CreateMap<ContaCorrenteViewModel, Conta>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => TipoConta.ContaCorrente));
        }
    }
}