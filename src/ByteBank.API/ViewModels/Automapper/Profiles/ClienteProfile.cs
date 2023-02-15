using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.ViewModels.Automapper.Profiles;
public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ContaRequest[], Conta[]>();

        CreateMap<EnderecoRequest, EnderecoCliente>();

        CreateMap<ClienteRequest, Cliente>();

        CreateMap<Cliente, ClienteViewModel>();
    }
}