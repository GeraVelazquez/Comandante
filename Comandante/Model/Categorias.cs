using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandante.Model
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public long IdCategoria { get; set; }
        public long IdCategoriaPadre { get; set; }
        public long IdAreaServicio { get; set; }
        [Required(ErrorMessage = "Se debe definir el nombre de la categoría.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string RGBIdentificador { get; set; }
        [StringLength(50)]
        public string Icono { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public long IdUsuarioCreo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        public Nullable<long> IdUsuarioModifico { get; set; }
        public Nullable<DateTime> FechaModifico { get; set; }
    }
}
