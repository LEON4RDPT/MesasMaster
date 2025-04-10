namespace Application.UseCases.UserService.GetUser;

public class GetUserResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool IsAdmin { get; set; }
}