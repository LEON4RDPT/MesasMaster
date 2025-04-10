namespace Application.UseCases.JwtService;

public interface IJwtTokenGenerator
{
    string GenerateToken(JwtUserRequest user);

}