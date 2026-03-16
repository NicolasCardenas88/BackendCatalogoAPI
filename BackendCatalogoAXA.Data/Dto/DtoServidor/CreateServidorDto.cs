using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCatalogoAXA.Data.Dto.DtoServidor
{
    public class CreateServidorDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int CategoriaServidorID { get; set; }
        public int EntornoID { get; set; }
        public int EstadoID { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioResponsable { get; set; }
        public DateTime? FechaResponsabilidad { get; set; }
        public int UnidadNegocioID { get; set; }
        public string IP { get; set; }
        public decimal? DiscoHDD_GB { get; set; }
        public decimal? Memoria_GB { get; set; }
        public decimal? MemoriaActual_GB { get; set; }
        public decimal? EspacioDisco_GB { get; set; }
        public decimal? EspacioActualDisco_GB { get; set; }
        public int SistemaOperativoID { get; set; }
        public int? CantidadCores { get; set; }
        public bool TieneRDP { get; set; }
        public DateTime? FechaApagado { get; set; }
        public int AmbienteID { get; set; }
        public string Dominio { get; set; }
        public string Aplicacion { get; set; }
        public int? Sockets { get; set; }
        public string Adapter { get; set; }
        public short? MotorBDID { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaDeComision { get; set; }
        public bool? ApagadoPorAmbiente { get; set; }
        public bool? MonitoreadoOrion { get; set; }
        public string AmbientesQA { get; set; }
        public string GruposRed { get; set; }
        public string Agrupacion { get; set; }
    }
}
