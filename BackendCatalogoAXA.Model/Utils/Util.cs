namespace BackendCatalogoAXA.Model.Utils
{
    public static class Util
    {
        public static int ObtenerIdEntidad<TEntidad>(TEntidad entidad)
        {
            var property = typeof(TEntidad)
                .GetProperties()
                .FirstOrDefault(p => p.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase));

            if (property != null)
            {
                var value = property.GetValue(entidad);
                if (value == null)
                    throw new InvalidOperationException($"La propiedad '{property.Name}' es null en la entidad.");

                return (int)value;
            }

            throw new InvalidOperationException("La entidad no tiene una propiedad de ID o no pudo obtenerla.");
        }


    }
}
