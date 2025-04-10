namespace Application.Exceptions.User;

public class LoginUnauthorizedException : Exception
{
    public LoginUnauthorizedException()
        : base("Não Autorizado!")
    {
        
    }
}