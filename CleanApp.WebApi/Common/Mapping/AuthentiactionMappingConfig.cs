using CleanApp.Application.Authentication;
using CleanApp.Contracts.Authentication;
using Mapster;

namespace CleanApp.Api.Common.Mapping;

public class AuthentiactionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
