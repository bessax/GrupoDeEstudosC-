using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles
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
                Cep = r.Endereco.Cep,
                CriadoEm = r.CriadoEm,
                AtualizadoEm = r.AtualizadoEm
            }));

            CreateMap<Agencia, AgenciaRequest>().ForMember(a => a.Endereco, r => r.MapFrom(r => new EnderecoRequest()
            {
                Logradouro = r.Endereco.Logradouro,
                Numero = r.Endereco.Numero,
                Complemento = r.Endereco.Complemento,
                Cep = r.Endereco.Cep,
                CriadoEm = r.CriadoEm,
                AtualizadoEm = r.AtualizadoEm
            }));

            CreateMap<Agencia, AgenciaViewModel>();

        }
    }
}