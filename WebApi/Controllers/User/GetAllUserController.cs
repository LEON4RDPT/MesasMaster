using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Application.UseCases.UserService.GetAllUsers;
using Core.Interfaces;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User;

[ApiController]
[Route("/api/user")]
public class GetAllUserController(GetAllUsersHandler handler) : ControllerBase
{
   private readonly GetAllUsersHandler _handler = handler;

   [HttpGet]
   public async Task<IActionResult> Get()
   {
      var users = await _handler.Handle();
      return Ok(users);
   }
   
}