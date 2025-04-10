using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Application.UseCases.UserService.GetAllUsers;
using Application.UseCases.UserService.GetUser;
using Core.Interfaces;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User;

[ApiController]
[Route("/api/user")]
public class GetUserController(GetUserHandler handler) : ControllerBase
{
    private readonly GetUserHandler _handler = handler;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var user = await _handler.Handle(new GetUserRequest
            {
                Id = id,
            });
            return Ok(user);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }
   
}