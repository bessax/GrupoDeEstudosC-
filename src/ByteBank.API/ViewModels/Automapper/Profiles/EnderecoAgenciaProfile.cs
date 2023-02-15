using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles
{
    public class EnderecoAgenciaProfile : Profile
    {
        public EnderecoAgenciaProfile()
        {
            CreateMap<EnderecoAgenciaRequest, EnderecoAgencia>();
            CreateMap<EnderecoAgencia,EnderecoAgenciaViewModel>();
        }
    }
}