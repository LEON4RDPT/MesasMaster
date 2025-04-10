namespace Application.UseCases.JwtService;

public class JwtUserRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsAdmin { get; set; }
}