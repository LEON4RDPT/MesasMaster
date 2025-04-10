namespace MesaApp.Application.UseCases.UserService.CreateUser;

public class CreateUserResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsAdmin { get; set; }
}