using Application.Exceptions.Shared;
using Application.Exceptions.User;
using Application.UseCases.UserService.CreateUser;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User
{
    [ApiController]
    [Route("api/user")]

    public class CreateUserController(CreateUserHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await handler.Handle(request);
                return CreatedAtAction(nameof(Post), new { id = response.Id }, response);
            }
            catch (EmailAlreadyInUseException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (MissingAttributeException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidAttributeException ex)
            {
                return BadRequest(new { message = ex.Message });
            }


        }
    }
}
