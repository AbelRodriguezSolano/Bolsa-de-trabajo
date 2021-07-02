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
    //Este procemiento no retornar valores,
    //para saber cuales procedimineto retornar valores revisar la documentacion oficial
    [Keyless]
    public class Insert_Vacante
    {
        public string Tipo { set; get; }
        public string Company { set; get; }
        public string Logo { set; get; }
        public string Posicion { set; get; }
        public string Ubicacion { set; get; }
        public string Descripcion { set; get; }
        public int Categoria{ set; get; }
        public int Usuario { set; get; }
        public string Url { set; get; }
    }
}
