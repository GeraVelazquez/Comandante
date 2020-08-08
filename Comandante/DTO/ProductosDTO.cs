using System;

namespace Comandante.DTO
{
    public class ProductosDTO
    {
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public double CostoPreparacion { get; set; }
        public int MinsPreparacion { get; set; }
        public long IdUsuarioCreo { get; set; }
        public DateTime FechaCreo { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<DateTime> FechaModifico { get; set; }
    }
}
