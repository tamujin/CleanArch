using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(),
                                        "firstName",
                                        "LastName",
                                        email,
                                        password,
                                        "Token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // check if user already exist
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        // Create user (Generate unique id)

        // create the token



        return new AuthenticationResult(Guid.NewGuid(),
                                        firstName,
                                        lastName,
                                        email,
                                        password,
                                       token);
    }
}