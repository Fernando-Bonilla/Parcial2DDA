using Microsoft.AspNetCore.Mvc;
using Parcial2DDA.DTOs;
using Parcial2DDA.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parcial2DDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly CalculosService _calculosService;

        public DatosController(CalculosService calculosService)
        {
            _calculosService = calculosService;
        }
        
        [HttpPost("/Medicion")]
        public async Task<ActionResult> post([FromBody] AgregarHuellaDTO huella)
        {
            if (huella == null)
            {
                return BadRequest("Por favor ingrese los datos");
            }
            
            await _calculosService.crearAltaHuella(huella);

            return Ok();
        }

        // GET: api/<DatosController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/


        // GET api/<DatosController>/5
        /* [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }

         // POST api/<DatosController>
         [HttpPost]
         public void Post([FromBody] string value)
         {
         }

         // PUT api/<DatosController>/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE api/<DatosController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
