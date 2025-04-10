using Application.Exceptions.Shared;
using Application.Exceptions.User;
using MesaApp.Application.UseCases.UserService.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User
{
    [ApiController]
    [Route("api/User")]

    public class CreateUserController : ControllerBase
    {
        private readonly CreateUserHandler _handler;

        public CreateUserController(CreateUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _handler.Handle(request);
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
