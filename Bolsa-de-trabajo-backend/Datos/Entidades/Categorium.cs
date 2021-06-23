using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Datos.Entidades
{
    [Index(nameof(Nombre), Name = "UQ__Categori__72AFBCC6742688DF", IsUnique = true)]
    public partial class Categorium
    {
        public Categorium()
        {
            Vacantes = new HashSet<Vacante>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Vacante.CategoriaNavigation))]
        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
