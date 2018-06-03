using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacesAPI.Models;

namespace PlacesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Places")]
    public class PlacesController : Controller
    {
        private readonly PlaceDbContext _context;

        public PlacesController(PlaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        public IEnumerable<Place> GetPlaces()
        {
            return _context.Places;
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = await _context.Places.SingleOrDefaultAsync(m => m.Id == id);

            if (place == null)
            {
                return NotFound();
            }

            return Ok(place);
        }

        // PUT: api/Places/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace([FromRoute] int id, [FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != place.Id)
            {
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Places
        [HttpPost]
        public async Task<IActionResult> PostPlace([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Places.Add(place);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlaceExists(place.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlace", new { id = place.Id }, place);
        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var place = await _context.Places.SingleOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();

            return Ok(place);
        }

        private bool PlaceExists(int id)
        {
            return _context.Places.Any(e => e.Id == id);
        }
    }
}