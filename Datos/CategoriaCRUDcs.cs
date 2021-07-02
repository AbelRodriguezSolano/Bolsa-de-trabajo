using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entidades;

namespace Datos
{
    public class CategoriaCRUD
    {
        public async Task<Categorium> Create(Categorium datos)
        {
            using(var db = new BolsaTrabajoContext())
            {
                try
                {
                await db.Categoria.AddAsync(datos);
                await db.SaveChangesAsync();
                    return datos;
                }
                catch
                {
                    return null;
                }
            }
        }
        public async Task<Categorium> Delete(int CategoriaID){
            using (var db = new BolsaTrabajoContext()) {
                var categoria = await ReadOne(CategoriaID);
                if (categoria != null)
                {
                    db.Categoria.Remove(categoria);
                    await db.SaveChangesAsync();
                    return categoria;
                }
                return null;
            }
        }
        public async Task<Categorium> Update(Categorium datos) { 
            using(var db = new BolsaTrabajoContext())
            {
                try
                {
                var d = await ReadOne(datos.Id);
                    if (d != null) {
                        d.Nombre = datos.Nombre;
                        db.Entry(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        return d;
                      }
                    return null;
                }
                catch
                {
                    return null; 
                }
            }
        }
        public List<Categorium> Read() {
        
            using(var db = new BolsaTrabajoContext())
            {
                var lista = (from d in db.Categoria
                                 select d).ToList();
                return lista;
             }
        }
        private async Task<Categorium> ReadOne(int id)
        {
            using(var db = new BolsaTrabajoContext())
            {
                try
                {
                    var categoria = await db.Categoria.FindAsync(id);
                    return categoria;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
