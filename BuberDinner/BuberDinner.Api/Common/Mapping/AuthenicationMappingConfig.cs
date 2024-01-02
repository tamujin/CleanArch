using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenicationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Redundant but might be good to put there so in future people can find it.
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResult>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.user);

    }
}
