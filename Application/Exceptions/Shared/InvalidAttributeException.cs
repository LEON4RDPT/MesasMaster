namespace Application.Exceptions.Shared;

public class InvalidAttributeException : Exception
{
    public InvalidAttributeException(string attribute)
        : base($"Atributo: {attribute} Inválido!")
    {
        Attribute = attribute;
    }

    public InvalidAttributeException(string attribute, string message)
        : base($"Atributo: {attribute} Inválido! \n{message}")
    {
        Attribute = attribute;
    }

    public string Attribute { get; }
}