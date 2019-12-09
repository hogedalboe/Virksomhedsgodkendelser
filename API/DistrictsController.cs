using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Data;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly VirksomhedsgodkendelserContext _context;

        public DistrictsController(VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetDistrict()
        {
            return await _context.District.ToListAsync();
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(int id)
        {
            var district = await _context.District.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }

        // PUT: api/Districts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict(int id, District district)
        {
            if (id != district.ID)
            {
                return BadRequest();
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
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

        // POST: api/Districts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
            _context.District.Add(district);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistrict", new { id = district.ID }, district);
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<District>> DeleteDistrict(int id)
        {
            var district = await _context.District.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.District.Remove(district);
            await _context.SaveChangesAsync();

            return district;
        }

        private bool DistrictExists(int id)
        {
            return _context.District.Any(e => e.ID == id);
        }
    }
}
