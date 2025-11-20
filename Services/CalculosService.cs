using Microsoft.AspNetCore.Mvc;
using Parcial2DDA.Data;
using Parcial2DDA.DTOs;
using Parcial2DDA.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            Registros? registroEntrada = _context.Registros
                .Where(r => r.Tipo == "entrada")
                .FirstOrDefault(r => r.Huella == huella);

            Registros? registroSalida = _context.Registros
                .Where(r => r.Tipo == "salida")
                .FirstOrDefault(r => r.Huella == huella);

            decimal peso = registroSalida.Peso - registroEntrada.Peso;
            int tiempoEntrada = (int)((DateTimeOffset)registroEntrada.Duracion).ToUnixTimeSeconds();
            int tiempoSalida = (int)((DateTimeOffset)registroSalida.Duracion).ToUnixTimeSeconds();
            int tiempoTotal = tiempoSalida - tiempoEntrada;

            Console.WriteLine("======================= entra calc");

            string Datos = $"Diferencia Peso: {peso}, Tiempo en el local: {tiempoTotal}";
            Console.WriteLine($"Diferencia Peso: {peso}, Tiempo en el local: {tiempoTotal} segundos");

            RegistroAuditoria registroAuditoria = new RegistroAuditoria();
            registroAuditoria.DiferenciaPeso = peso;
            registroAuditoria.DiferenciaTiempo = tiempoTotal;

            _context.RegistroAuditoria.Add(registroAuditoria);
            _context.Registros.Remove(registroEntrada);
            _context.Registros.Remove(registroSalida);

            _context.SaveChangesAsync();
            
            return Datos;
        }

        public async Task<int> medicionesCompletadas()
        {
            int total = _context.RegistroAuditoria.Count();

            return total;
        }

        public async Task<decimal> mayorDiferenciaPeso()
        {
            /*decimal peso = await _context.RegistroAuditoria
                .OrderByDescending(r => r.DiferenciaPeso)
                .Take(1)
                .Select();  */

            decimal peso = await _context.RegistroAuditoria.MaxAsync(r => r.DiferenciaPeso);

            return peso;
        }
    }
}
