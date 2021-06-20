using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entidades;
using Datos;

namespace Negocios
{
    public class ConsultasCategorias
    {
       private CategoriaCRUD consulta = new CategoriaCRUD();
        Categorium ob;
       public async Task<Categorium> AddCategoria(CategoriaRequest datos)
        {
            ob = new Categorium();
            ob.Nombre = datos.nombre;
            return await consulta.Create(ob);
        }
        public List<Categorium> ListaCategoria()
        {
            return consulta.Read();
        }
        public async Task<Categorium> UpdateCategoria(CategoriaRequest data)
        {
            ob = new Categorium();
            ob.Id = data.IdCategoria;
            ob.Nombre = data.nombre;
            return await consulta.Update(ob);
        }
        public async Task<Categorium> DeleteCategoria(int id)
        {
            return await consulta.Delete(id);
        }
        
    }
}
