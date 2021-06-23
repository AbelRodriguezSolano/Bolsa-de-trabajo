using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entidades
{
    public partial class Vacante
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Company { get; set; }
        public string DireccionUrl { get; set; }
        public string Logo { get; set; }
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CorreoAplicar { get; set; }
        public int Categoria { get; set; }
        public string Estado { get; set; }
        public int Usuario { get; set; }

        public virtual Categorium CategoriaNavigation { get; set; }
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
