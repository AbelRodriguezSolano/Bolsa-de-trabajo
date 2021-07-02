using System;
using System.Collections.Generic;

#nullable disable

namespace Datos.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Vacantes = new HashSet<Vacante>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
