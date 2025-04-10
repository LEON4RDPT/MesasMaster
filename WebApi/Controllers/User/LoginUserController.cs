using Application.Exceptions.User;
using Application.UseCases.UserService.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User;

[ApiController]
[Route("/api/login")]
public class LoginUserController(LoginUserHandler handler) : ControllerBase
{
    private readonly LoginUserHandler _handler = handler;
    [HttpPost]
    public async Task<IActionResult> Post(LoginUserRequest request)
    {
        try
        {
            var token = await _handler.Handle(request);
            return Ok(new { Token = token });
        }
        catch (LoginUnauthorizedException)
        {
            return Unauthorized();
        }
        catch (UserNotFoundException)
        {
            return NotFound();
        }
    }
}