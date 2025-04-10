using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Shared
{
    public class InvalidAttributeException : Exception
    {
        public string Attribute { get; }

        public InvalidAttributeException(string attribute) 
            : base($"Atributo: {attribute} Inválido!")
        {
            this.Attribute = attribute;
        }

        public InvalidAttributeException(string attribute, string message)
            : base($"Atributo: {attribute} Inválido! \n{message}")
        {
            this.Attribute = attribute;
        }
    }
}
