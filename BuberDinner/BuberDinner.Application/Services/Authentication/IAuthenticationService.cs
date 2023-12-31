namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService {
    AuthenticationResult Login(string email, string password );
    AuthenticationResult Register(string firsName, string lastName, string email, string password );
}