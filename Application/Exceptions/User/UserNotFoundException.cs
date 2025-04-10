namespace Application.Exceptions.User;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(int id)
        : base($"Utilizador com o id: {id} não foi encontrado!")
    {
        Id = id;
    }

    public int Id { get; }
}