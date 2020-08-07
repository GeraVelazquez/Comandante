using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandante.Model
{
    [Table("AreasServicio")]
    public class AreasServicio
    {
        [Key]
        public long IdArea { get; set; }
        [Required(ErrorMessage = "Se debe definir el nombre del área.")]
        [StringLength(50)]
        public string Nombre { get; set; }
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
