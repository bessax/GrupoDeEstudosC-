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
            CreateMap<AgenciaRequest, Agencia>().ForMember(a => a.Endereco, r => r.MapFrom(r => new EnderecoAgencia()
            {
                Logradouro = r.Endereco.Logradouro,
                Numero = r.Endereco.Numero,
                Complemento = r.Endereco.Complemento,
                Cep = r.Endereco.Cep
            }));

            CreateMap<Agencia, AgenciaViewModel>();
        }
    }
}