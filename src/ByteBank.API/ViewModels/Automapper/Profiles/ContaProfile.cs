using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.ViewModels.Automapper.Profiles;
public class ContaProfile : Profile
{
    public ContaProfile()
    {
        CreateMap<ContaRequest, Conta>();
    }
}