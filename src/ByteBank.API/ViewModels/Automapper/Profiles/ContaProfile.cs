using AutoMapper;
using ByteBank.API.Enums;
using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.ViewModels.Automapper.Profiles;
public class ContaProfile : Profile
{
    public ContaProfile()
    {
        CreateMap<ContaRequest, Conta>();

        CreateMap<ContaCorrenteViewModel, Conta>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => TipoConta.ContaCorrente));

        CreateMap<Conta, ContaCorrenteViewModel>();
    }
}