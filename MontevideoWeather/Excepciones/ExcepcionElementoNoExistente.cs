using System;

namespace Excepciones
{
    public class ExcepcionElementoNoExistente: Exception
    {
        public ExcepcionElementoNoExistente() : base() { }

        public ExcepcionElementoNoExistente(string message) : base(message) { }

        public ExcepcionElementoNoExistente(string message, Exception innerException) : base(message, innerException) { }
    }
}