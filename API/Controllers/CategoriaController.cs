using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Entidades;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Allowed")]

    public class CategoriaController : ControllerBase
    {
        ConsultasCategorias data = new ConsultasCategorias();
        [HttpGet]
        public ActionResult<List<Categorium>> GetCategoria()
        {
            try
            {

                var lista = data.ListaCategoria();
                if (lista != null) return Ok(lista);
                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }         
            
        }
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategoria([FromBody]CategoriaRequest cr)
        {
            return (await data.AddCategoria(cr) is null) ? BadRequest() : Ok(cr);
        }
        [HttpPut]
        public async Task<ActionResult<Categorium>> PutCategoria([FromBody]CategoriaRequest cr)
        {
            return (await data.UpdateCategoria(cr) is null) ? NotFound() : Ok(cr);
        }
        [HttpDelete]
        public async Task<ActionResult<Categorium>> DeleteCategoria([FromBody]CategoriaRequest cr)
        {
            return (await data.DeleteCategoria(cr.IdCategoria) is null) ? BadRequest() : Ok(cr);
        }

    }
}
