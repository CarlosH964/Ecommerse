using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerse.Data;
using Ecommerse.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreVController : ControllerBase
    {
        private readonly Central _context;

        public PreVController(Central context)
        {
            _context = context;
        }

        // GET: api/PreV
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreVResponseModel>>> GetPreV()
        {
            var preVs = await _context.PreV
                .Include(p => p.User)
                .ToListAsync();

            var response = preVs.Select(p => new PreVResponseModel
            {
                PrevId = p.PrevId,
                UserId = p.UserId,
                Fecha = p.Fecha,
                UserName = p.User.Name,
                UserEmail = p.User.Email
            }).ToList();

            return response;
        }


        // POST: api/PreV
        [HttpPost]
        public async Task<ActionResult<PreV>> PostPreV(PreVInputModel inputModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == inputModel.UserId);

            if (user == null)
            {
                return BadRequest("El usuario con el Id proporcionado no existe.");
            }

            var prev = new PreV
            {
                UserId = inputModel.UserId,
                Fecha = inputModel.Fecha
            };

            _context.PreV.Add(prev);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreV", new { id = prev.PrevId }, prev);
        }

        // PUT: api/PreV/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreV(int id, PreV preV)
        {
            if (id != preV.PrevId)
            {
                return BadRequest();
            }

            _context.Entry(preV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreVExists(id))
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

        // DELETE: api/PreV/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreV(int id)
        {
            var preV = await _context.PreV.FindAsync(id);
            if (preV == null)
            {
                return NotFound();
            }

            _context.PreV.Remove(preV);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreVExists(int id)
        {
            return _context.PreV.Any(e => e.PrevId == id);
        }

        public class PreVInputModel
        {
            public int UserId { get; set; }
            public DateTime Fecha { get; set; }
        }

        public class PreVResponseModel
        {
            public int PrevId { get; set; }
            public int UserId { get; set; }
            public DateTime Fecha { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
        }
    }
}
