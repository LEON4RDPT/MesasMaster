namespace Application.Exceptions.Shared
{
    public class MissingAttributeException : Exception
    {
        public string AtributeName { get; }

        public MissingAttributeException(string atributeName) :
            base($"O atributo: {atributeName} está em falta!")
        {
            AtributeName = atributeName;
        }
    }
}
