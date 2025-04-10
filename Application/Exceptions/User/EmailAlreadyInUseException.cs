
namespace Application.Exceptions.User
{
    public class EmailAlreadyInUseException : Exception
    {
        public string EmailAlreadyInUse { get; }

        public EmailAlreadyInUseException(string emailAlreadyInUse)
            : base($"O email {emailAlreadyInUse} já está em uso!")
        {
            EmailAlreadyInUse = emailAlreadyInUse;
        }
    }
}
