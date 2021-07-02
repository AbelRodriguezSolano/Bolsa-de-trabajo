using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Datos.Entidades
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Vacantes = new HashSet<Vacante>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(15)]
        public string Rol { get; set; }
        [Required]
        [StringLength(30)]
        public string Correo { get; set; }
        [Required]
        [StringLength(20)]
        public string Contrasena { get; set; }

        [InverseProperty(nameof(Vacante.UsuarioNavigation))]
        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
