using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Profiles;
public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        this.CreateMap<ContaRequest[], Conta[]>();

        this.CreateMap<EnderecoRequest, EnderecoCliente>();

        this.CreateMap<ClienteRequest, Cliente>();

        this.CreateMap<Cliente, ClienteViewModel>();
    }
}