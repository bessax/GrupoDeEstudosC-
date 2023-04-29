using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles;
public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ContaRequest, Conta>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
        .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
        .ForMember(dest => dest.ExcluidoEm, opt => opt.Ignore());

        CreateMap<EnderecoRequest, EnderecoCliente>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExcluidoEm, opt => opt.Ignore());

        CreateMap<ClienteRequest, Cliente>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
            .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
            .ForMember(dest => dest.ExcluidoEm, opt => opt.Ignore())
            .ForMember(dest => dest.Contas, opt => opt.MapFrom(req => req.Contas));

        CreateMap<Cliente, ClienteViewModel>();
    }
}