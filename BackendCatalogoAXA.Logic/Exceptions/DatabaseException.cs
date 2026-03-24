using System;

namespace BackendCatalogoAXA.Logic.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base("Error en la base de datos") { }

        public DatabaseException(string message) : base(message) { }

        public DatabaseException(string message, Exception innerException) : base(message, innerException) { }
    }
}