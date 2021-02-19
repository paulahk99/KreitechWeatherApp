using System;

namespace Excepciones
{
    public class ExcepcionPalabraLarga : Exception
    {
        public ExcepcionPalabraLarga() : base() { }

        public ExcepcionPalabraLarga(string message) : base(message) { }

        public ExcepcionPalabraLarga(string message, Exception innerException) : base(message, innerException) { }

    }
}