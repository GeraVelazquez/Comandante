using System;

namespace Comandante.DTO
{
    public class CategoriasDTO
    {
        public long IdCategoria { get; set; }
        public Nullable<long> IdCategoriaPadre { get; set; }
        public long IdAreaServicio { get; set; }
        public string Nombre { get; set; }
        public string RGBIdentificador { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }
        public long IdUsuarioCreo { get; set; }
        public DateTime FechaCreo { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<DateTime> FechaModifico { get; set; }
    }
}
