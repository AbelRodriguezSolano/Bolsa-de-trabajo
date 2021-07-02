using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entidades
{
    public partial class Categorium
    {
        public Categorium()
        {
            Vacantes = new HashSet<Vacante>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
