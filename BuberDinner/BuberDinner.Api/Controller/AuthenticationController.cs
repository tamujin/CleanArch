using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(Contracts.Authentication.RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName,
                                                                                                          request.LastName,
                                                                                                          request.Email,
                                                                                                          request.Password);
        return registerResult.Match(
            authResult => Ok(MapAutResults(authResult)),
            errors => Problem(errors)
        );
    }

    private AuthenticationResponse MapAutResults(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.user.Id,
                                                  authResult.user.FirstName,
                                                  authResult.user.LastName,
                                                  authResult.user.Email,
                                                  authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(Contracts.Authentication.LoginRequest request)
    {
        ErrorOr<AuthenticationResult> loginResult = _authenticationService.Login(request.Email,
                                                                             request.Password);
        return loginResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors)
        );
    }
}
