using System;

namespace Comandante.DTO
{
    public class AreasServicioDTO
    {
        public long IdArea { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public long IdUsuarioCreo { get; set; }
        public DateTime FechaCreo { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<DateTime> FechaModifico { get; set; }
    }
}
