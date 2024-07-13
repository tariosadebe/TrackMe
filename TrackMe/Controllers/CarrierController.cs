using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackMe.Data;
using TrackMe.Models.Entities;

namespace TrackMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly TrackMeContext _context;

        public CarrierController(TrackMeContext context)
        {
            _context = context;
        }

        // GET: api/Carrier
        [HttpGet("GetCarriers")]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarriers()
        {
            return await _context.Carriers.ToListAsync();
        }

        // GET: api/Carrier/5
        [HttpGet("GetCarrierById/{id}")]
        public async Task<ActionResult<Carrier>> GetCarrier(int id)
        {
            var carrier = await _context.Carriers.FindAsync(id);

            if (carrier == null)
            {
                return NotFound();
            }

            return carrier;
        }

        // POST: api/Carrier
        [HttpPost("PostCarrier")]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
            _context.Carriers.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.Id }, carrier);
        }

        // PUT: api/Carrier/5
        [HttpPut("PutCarrierById/{id}")]
        public async Task<IActionResult> PutCarrier(int id, Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierExists(id))
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

        // DELETE: api/Carrier/5
        [HttpDelete("DeleteCarrierById/{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            var carrier = await _context.Carriers.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }

            _context.Carriers.Remove(carrier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrierExists(int id)
        {
            return _context.Carriers.Any(e => e.Id == id);
        }
    }
}
