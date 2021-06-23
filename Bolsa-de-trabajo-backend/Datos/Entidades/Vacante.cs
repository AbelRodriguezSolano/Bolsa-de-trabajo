using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Datos.Entidades
{
    [Table("Vacante")]
    public partial class Vacante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(50)]
        public string Company { get; set; }
        [Column("Direccion_url")]
        public string DireccionUrl { get; set; }
        public string Logo { get; set; }
        [Required]
        [StringLength(50)]
        public string Posicion { get; set; }
        [Required]
        [StringLength(100)]
        public string Ubicacion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }
        [Required]
        [StringLength(30)]
        public string CorreoAplicar { get; set; }
        public int Categoria { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
        public int Usuario { get; set; }

        [ForeignKey(nameof(Categoria))]
        [InverseProperty(nameof(Categorium.Vacantes))]
        public virtual Categorium CategoriaNavigation { get; set; }
        [ForeignKey(nameof(Usuario))]
        [InverseProperty("Vacantes")]
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
