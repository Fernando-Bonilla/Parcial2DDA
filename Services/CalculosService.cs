using Microsoft.AspNetCore.Mvc;
using Parcial2DDA.Data;
using Parcial2DDA.DTOs;
using Parcial2DDA.Models;

namespace Parcial2DDA.Services
{
    public class CalculosService
    {
        private readonly AppDbContext _context;

        public CalculosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Registros> crearAltaHuella(AgregarHuellaDTO dto)
        {
            Registros nuevoRegistro = new Registros();

            nuevoRegistro.Huella = dto.Huella;
            nuevoRegistro.Peso = dto.Peso;
            nuevoRegistro.Tipo = dto.Tipo;

            await _context.Registros.AddAsync(nuevoRegistro);
            await _context.SaveChangesAsync();

            return(nuevoRegistro);
        }

        public string calculos(string huella)
        {
            return "hola";
        }
    }
}
