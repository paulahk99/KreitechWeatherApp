using System;

namespace Excepciones
{
    public class ExcepcionFueraDeFecha : Exception
    {
        public ExcepcionFueraDeFecha() : base() { }

        public ExcepcionFueraDeFecha(string message) : base(message) { }

        public ExcepcionFueraDeFecha(string message, Exception innerException) : base(message, innerException) { }
    }
}