using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Application.UseCases.UserService.GetAllUsers;
using Application.UseCases.UserService.GetUser;
using Application.UseCases.UserService.PutUser;
using Core.Interfaces;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User;

[ApiController]
[Route("/api/user")]
public class PutUserController(PutUserHandler handler) : ControllerBase
{
    private readonly PutUserHandler _handler = handler;

    [HttpPut]
    public async Task<IActionResult> Put(PutUserRequest request)
    {
        try
        {
            await _handler.Handle(request);
            return NoContent();
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (EmailAlreadyInUseException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
   
}