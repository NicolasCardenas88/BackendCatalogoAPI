namespace BackendCatalogoAXA.Model.Utils
{
    public static class Util
    {
        public static int ObtenerIdEntidad<TEntidad>(TEntidad entidad)
        {
            var property = typeof(TEntidad).GetProperty("LogId") ?? typeof(TEntidad).GetProperty("Id");
            if (property != null)
            {
                return (int)property.GetValue(entidad);
            }
            throw new InvalidOperationException("La entidad no tiene una propiedad de ID o no pudo obtenerla.");
        }

    }
}
