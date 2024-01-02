using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Contracts.Authentication.RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
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
        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);
        return loginResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors)
        );
    }
}
