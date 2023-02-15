using AutoMapper;

using ByteBank.API.Models;
using ByteBank.API.Request;

namespace ByteBank.API.Profiles;
public class ContaProfile : Profile
{
    public ContaProfile()
    {
        this.CreateMap<ContaRequest, Conta>();
    }
}