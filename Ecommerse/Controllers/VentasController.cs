using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerse.Data;
using Ecommerse.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly Central _context;

        public VentasController(Central context) 
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas() 
        {
            return await _context.Ventas.ToListAsync();
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetObjectsVentas(int id)
        {
            var objectsVentas = await _context.Ventas.FindAsync(id);

            if (objectsVentas == null)
            {
                return NotFound();
            }

            return objectsVentas;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectsVentas(int id, Ventas objectsVentas)
        {
            if (id != objectsVentas.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectsVentas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectsVentasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var response = NoContent();
            return response;
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostObjectsVentas(Ventas objectsVentas)
        {
            _context.Ventas.Add(objectsVentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectsVentas", new { id = objectsVentas.Id }, objectsVentas);
        }

        // DELETE:
        [HttpDelete("{id}")]  
        public async Task<IActionResult> DeleteObjectsVentas(int id)
        {
            var objectsVentas = await _context.Ventas.FindAsync(id);
            if (objectsVentas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(objectsVentas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectsVentasExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }

    }
}
