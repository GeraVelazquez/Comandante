using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandante.Model
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public double CostoPreparacion { get; set; }
        public int MinsPreparacion { get; set; }
        [Required]
        public long IdUsuarioCreo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<DateTime> FechaModifico { get; set; }
    }
}
