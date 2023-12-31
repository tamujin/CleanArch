using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controller;

[ApiController]
[Route("auth")]
public class  AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(Contracts.Authentication.RegisterRequest request)
    {
        return Ok(_authenticationService.Register(request.FirstName,
                                                  request.LastName,
                                                  request.Email,
                                                  request.Password));
    }
    
    [HttpPost("login")]
    public IActionResult Login(Contracts.Authentication.LoginRequest request)
    {
        return Ok(_authenticationService.Login(request.Email,
                                               request.Password));
    }
}
