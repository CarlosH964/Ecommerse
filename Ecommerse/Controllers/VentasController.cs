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
    public class VentasController : ControllerBase
    {
        private readonly Central _context;

        public VentasController(Central context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentasResponseModel>>> GetVentas()
        {
            var ventas = await _context.Ventas
                .Include(v => v.Items)
                .Include(v => v.Prev)
                    .ThenInclude(p => p.User)
                .ToListAsync();

            var response = ventas.Select(v => new VentasResponseModel
            {
                VentaDId = v.VentaDId,
                ItemsId = v.ItemsId ,
                ItemsName = v.Items.Name,
                IdPrev = v.IdPrev,
                UserId = v.Prev.User != null ? v.Prev.User.IdUser : 0,
                UserName = v.Prev.User != null ? v.Prev.User.Name : "No asignado",
                Total = v.Total
            }).ToList();

            return response;
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentasResponseModel>> GetVenta(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.Items)
                .Include(v => v.Prev)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(v => v.VentaDId == id);

            if (venta == null)
            {
                return NotFound();
            }

            var response = new VentasResponseModel
            {
                VentaDId = venta.VentaDId,
                ItemsId = venta.ItemsId,
                ItemsName = venta.Items.Name,
                IdPrev = venta.IdPrev,
                UserId = venta.Prev.User != null ? venta.Prev.User.IdUser : 0,
                UserName = venta.Prev.User != null ? venta.Prev.User.Name : "No asignado",
                Total = venta.Total
            };

            return response;
        }

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVenta(VentasInputModel inputModel)
        {
            if (inputModel == null)
            {
                return BadRequest("The inputModel field is required.");
            }

            var prev = await _context.PreV.FirstOrDefaultAsync(p => p.PrevId == inputModel.IdPrev);
            if (prev == null)
            {
                return BadRequest("La PreV especificada no existe.");
            }

            var items = await _context.Items
                .Where(i => inputModel.ItemsIds.Contains(i.IdItems))
                .ToListAsync();

            if (items.Count != inputModel.ItemsIds.Count)
            {
                return BadRequest("Algunos de los Items especificados no existen.");
            }

            var venta = new Ventas
            {
                IdPrev = inputModel.IdPrev,
                Total = inputModel.Total
            };

            foreach (var itemId in inputModel.ItemsIds)
            {
                venta.ItemsId = itemId;
                _context.Ventas.Add(venta);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenta), new { id = venta.VentaDId }, venta);
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Ventas venta)
        {
            if (id != venta.VentaDId)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaDId == id);
        }
    }

    public class VentasInputModel
    {
        public List<int> ItemsIds { get; set; }
        public int IdPrev { get; set; }
        public int Total { get; set; }
    }

    public class VentasResponseModel
    {
        public int VentaDId { get; set; }
        public int ItemsId { get; set; }
        public string ItemsName { get; set; }
        public int IdPrev { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Total { get; set; }
    }
}
