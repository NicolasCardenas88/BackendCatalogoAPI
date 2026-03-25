namespace BackendCatalogoAXA.Logic.Exceptions {
    public class AlreadyExistsException : Exception {
        public AlreadyExistsException() : base("El recurso ya existe") { }
        public AlreadyExistsException(string message) : base(message) { }
        public AlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}