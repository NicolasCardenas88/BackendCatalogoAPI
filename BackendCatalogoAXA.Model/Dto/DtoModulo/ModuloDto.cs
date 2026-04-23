using BackendCatalogoAXA.Model.Dto.DtoAplicacion;

namespace BackendCatalogoAXA.Model.Dto.Modulo
{
    public class ModuloDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        // Se conserva la relación con Aplicacion
        public AplicacionDto? Aplicacion { get; set; }
    }
}