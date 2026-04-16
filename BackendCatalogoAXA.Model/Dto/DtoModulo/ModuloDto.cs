using BackendCatalogoAXA.Model.Dto.DtoAplicacion;

namespace BackendCatalogoAXA.Model.Dto.Modulo
{
    public class ModuloDto
    {
        public string Codigo {  get; set; }
        public AplicacionDto AplicacionId { get; set; }
        public string Nombre { get; set; }
    }
}
