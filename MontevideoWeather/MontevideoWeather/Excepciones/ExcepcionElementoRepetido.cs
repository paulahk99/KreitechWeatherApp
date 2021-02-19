using System;

namespace Excepciones
{
    public class ExcepcionElementoRepetido : Exception
    {
        public ExcepcionElementoRepetido() : base() { }
       
        public ExcepcionElementoRepetido(string message) : base(message) { }

        public ExcepcionElementoRepetido(string message, Exception innerException) : base(message, innerException) { }
    }
}