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

            string tipoHuella = huella.Tipo.Trim().ToLower();           

            await _calculosService.crearAltaHuella(huella);

            Console.WriteLine(tipoHuella);
            if (tipoHuella == "salida")
            {
                _calculosService.calculos(huella.Huella);
            }

            return Ok();
        }

        [HttpGet("/reportes/total")]
        public async Task<ActionResult> obtenerTotalMediociones()
        {
            int total = await _calculosService.medicionesCompletadas();

            return Ok(new {Total_mediciones_completadas = total} );
        }

        [HttpGet("/reportes/maxima_diferencia_peso")]
        public async Task<ActionResult> obtenerMayorDiferenciaPeso()
        {
            decimal total = await _calculosService.mayorDiferenciaPeso();

            return Ok(new { maxima_diferencia_peso = total });
        }
      
    }
}
