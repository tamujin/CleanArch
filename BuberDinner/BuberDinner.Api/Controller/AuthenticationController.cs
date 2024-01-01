using BuberDinner.Api.Filters;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace BuberDinner.Api.Controller;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(Contracts.Authentication.RegisterRequest request)
    {
        OneOf<AuthenticationResult, DuplicateEmailError> registerResult = _authenticationService.Register(request.FirstName,
                                                                                                          request.LastName,
                                                                                                          request.Email,
                                                                                                          request.Password);
        return registerResult.Match(
            authResult => Ok(MapAutResults(authResult)),
            _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists")
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
        return Ok(_authenticationService.Login(request.Email,
                                               request.Password));
    }
}
