using Application.Exceptions.User;
using Application.UseCases.UserService.DeleteUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User;

[ApiController]
[Route("/api/user")]
public class DeleteUserController(DeleteUserHandler handler) : ControllerBase
{
    private readonly DeleteUserHandler _handler = handler;

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _handler.Handle(id);
            return NoContent();
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }
}