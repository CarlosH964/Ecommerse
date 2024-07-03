using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerse.Data;
using Ecommerse.Models;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectsEcommercesController : ControllerBase
    {
        private readonly Central _context;

        public ObjectsEcommercesController(Central context)
        {
            _context = context;
        }

        // GET: api/ObjectsEcommerces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectsEcommerce>>> GetEcommerce()
        {
            return await _context.Ecommerce.ToListAsync();
        }

        // GET: api/ObjectsEcommerces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectsEcommerce>> GetObjectsEcommerce(int id)
        {
            var objectsEcommerce = await _context.Ecommerce.FindAsync(id);

            if (objectsEcommerce == null)
            {
                return NotFound();
            }

            return objectsEcommerce;
        }

        // PUT: api/ObjectsEcommerces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectsEcommerce(int id, ObjectsEcommerce objectsEcommerce)
        {
            if (id != objectsEcommerce.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectsEcommerce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectsEcommerceExists(id))
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

        // POST: api/ObjectsEcommerces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectsEcommerce>> PostObjectsEcommerce(ObjectsEcommerce objectsEcommerce)
        {
            _context.Ecommerce.Add(objectsEcommerce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectsEcommerce", new { id = objectsEcommerce.Id }, objectsEcommerce);
        }

        // DELETE: api/ObjectsEcommerces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectsEcommerce(int id)
        {
            var objectsEcommerce = await _context.Ecommerce.FindAsync(id);
            if (objectsEcommerce == null)
            {
                return NotFound();
            }

            _context.Ecommerce.Remove(objectsEcommerce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectsEcommerceExists(int id)
        {
            return _context.Ecommerce.Any(e => e.Id == id);
        }
    }
}
