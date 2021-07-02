using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    { 

        ////Peticion Get de usuarios
        [HttpGet]
        public ActionResult Get()
        {

            using(Datos.Models.BolsaTrabajoContext bdD = new Datos.Models.BolsaTrabajoContext())
            {
                var GettingData = (from d in bdD.Usuarios select d).ToList();
                return Ok(GettingData);
            }
        }

        ////Peticion post de usuarios
        public ActionResult Post([FromBody] Datos.Models.Usuario User_)
        {
            using (Datos.Models.BolsaTrabajoContext bdD = new Datos.Models.BolsaTrabajoContext())
            {
                Datos.Models.Usuario User_Edit = new Datos.Models.Usuario();
                User_Edit.Nombre = User_.Nombre;
                User_Edit.Rol = User_.Rol;
                User_Edit.Correo = User_.Correo;
                User_Edit.Contrasena = User_.Contrasena;
                bdD.Usuarios.Add(User_Edit);
                bdD.SaveChanges();
            }
            return Ok();
        }

        ////Peticion put de usuarios
        [HttpPut]
        public ActionResult Put([FromBody] Datos.Models.Usuario User_)
        {
            using (Datos.Models.BolsaTrabajoContext bdD = new Datos.Models.BolsaTrabajoContext())
            {
                Datos.Models.Usuario Usuario = bdD.Usuarios.Find(User_.Id);
                Usuario.Nombre = User_.Nombre;
                Usuario.Rol = User_.Rol;
                Usuario.Correo = User_.Correo;
                Usuario.Contrasena = User_.Contrasena;
                bdD.Entry(Usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                bdD.SaveChanges();
            }
            return Ok();
        }


        ////Peticion delete de usuarios
        [HttpDelete]
        public ActionResult Delete([FromBody] Datos.Models.Usuario User_)
        {
            using (Datos.Models.BolsaTrabajoContext bdD = new Datos.Models.BolsaTrabajoContext())
            {
                Datos.Models.Usuario UsuarioDelete = bdD.Usuarios.Find(User_.Id);
                bdD.Usuarios.Remove(UsuarioDelete);
                bdD.SaveChanges();

            }
            return Ok();
        }

    }
}
