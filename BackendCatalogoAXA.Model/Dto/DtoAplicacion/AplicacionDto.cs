using BackendCatalogoAXA.Model.Dto.DtoActivo;
using BackendCatalogoAXA.Model.Dto.DtoEstado;
using BackendCatalogoAXA.Model.Dto.DtoFramework;
using BackendCatalogoAXA.Model.Dto.DtoUnidadNegocio;


namespace BackendCatalogoAXA.Model.Dto.DtoAplicacion
{
    public class AplicacionDto
    {

        public string Codigo { get; set; }
        public ActivoDto? Activo { get; set; }
        public string NombreApp { get; set; }
        public string DescripcionFuncional { get; set; }
        public EstadoDto? Estado { get; set; }
        public FrameworkDto? Framework { get; set; }
        public string URLTST { get; set; }
        public string URLUAT { get; set; }
        public string URLProd { get; set; }
        public UnidadNegocioDto? UnidadNegocio { get; set; }
    }
}
