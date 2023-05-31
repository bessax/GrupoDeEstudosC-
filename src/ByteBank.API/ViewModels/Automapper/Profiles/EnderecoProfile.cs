using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoAgenciaRequest, EnderecoAgencia>();
            CreateMap<EnderecoAgencia, EnderecoAgenciaViewModel>()
                .ForSourceMember(source => source.ExcluidoEm, opt => opt.DoNotValidate());

            CreateMap<EnderecoRequest, EnderecoCliente>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.CriadoEm, opt => opt.Ignore())
                       .ForMember(dest => dest.AtualizadoEm, opt => opt.Ignore())
                       .ForMember(dest => dest.ExcluidoEm, opt => opt.Ignore());
        }
    }
}