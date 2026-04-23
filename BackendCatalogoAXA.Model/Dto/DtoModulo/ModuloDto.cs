using BackendCatalogoAXA.Model.Dto.DtoAplicacion;

namespace BackendCatalogoAXA.Model.Dto.Modulo
{
    public class ModuloDto
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        // Referencia ligera a Aplicacion
        public string? CodigoAplicacion { get; set; }
        // Objeto completo si se necesita más detalle
        public AplicacionDto? Aplicacion { get; set; }
    }
}