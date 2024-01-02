using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Contracts.Authentication.RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName,
                                          request.LastName,
                                          request.Email,
                                          request.Password);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

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
    public async Task<IActionResult> Login(Contracts.Authentication.LoginRequest request)
    {
        var query = new LoginQuery(request.Email,
                                   request.Password);

        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);
        return loginResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors)
        );
    }
}
