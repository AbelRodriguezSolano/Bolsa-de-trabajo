using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datos.Entidades.Procedimientos
{
    [Keyless]
    public class Filtrar_Vacante
    {
        
        public string Company { set; get; }
        public string Ubicacion { set; get; }
        public string Posicion { set; get; }
    }
}
