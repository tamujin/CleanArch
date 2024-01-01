using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    Result<AuthenticationResult> Register(string firsName, string lastName, string email, string password);
}