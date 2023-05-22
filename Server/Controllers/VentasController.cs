using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp_Act17.Server.Data;
using BlazorApp_Act17.Shared.Clases;
using BlazorApp_Act17.Client.Pages.Producto;
using BlazorApp_Act17.Client.Pages.Venta;

namespace BlazorApp_Act17.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly BDProveedoresContext _context;

        public VentasController(BDProveedoresContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }
            //return await _context.Ventas.ToListAsync();
            return await _context.Ventas
            .Include(v => v.Productos)
            .ToListAsync();
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetVentas(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }
            //var ventas = await _context.Ventas.Include(r => r.Productos).FirstOrDefaultAsync(v => v.Id == id);
            //Codigo editado
            var ventas = await _context.Ventas
             .Include(v => v.Productos)
             .FirstOrDefaultAsync(v => v.Id == id);

            if (ventas == null)
            {
                return NotFound();
            }

            return ventas;
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id, Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return BadRequest();
            }

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
        public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
        {
            //if (_context.Ventas == null)
            //{
            //return Problem("Entity set 'BDProveedoresContext.Ventas'  is null.");
            //}
            //Codigo copia
            if(ventas.ProductosIds != null && ventas.ProductosIds.Any())
            {
                ventas.Productos = new List<Productos>();

                foreach (var productoId in ventas.ProductosIds)
                {
                    var producto = await _context.Productos.FindAsync(productoId);
                    if (producto != null)
                    {
                        ventas.Productos.Add(producto);
                    }
                } 
            }
                _context.Ventas.Add(ventas);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetVenta", new { id = ventas.Id }, ventas);
                //Codigo Original
                // _context.Ventas.Add(ventas);
                //await _context.SaveChangesAsync();

                //return CreatedAtAction("GetVentas", new { id = ventas.Id }, ventas);
        }


        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }
            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return (_context.Ventas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
