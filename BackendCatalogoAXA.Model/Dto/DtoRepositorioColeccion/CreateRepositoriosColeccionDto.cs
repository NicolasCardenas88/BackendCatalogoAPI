namespace BackendCatalogoAXA.Model.Dto.DtoRepositorioColeccion
{
    public class CreateRepositoriosColeccionDto
    {
        public string Codigo { get; set; }
        public int ServicioId { get; set; }
        public string UrlColeccion { get; set; }
        public string UrlColeccionAzure { get; set; } 
    }
}
