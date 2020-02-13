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
    public class MunicipalitiesController : ControllerBase
    {
        private readonly VirksomhedsgodkendelserContext _context;

        public MunicipalitiesController(VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        // GET: api/Municipalities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipality()
        {
            return await _context.Municipality.ToListAsync();
        }

        // GET: api/Municipalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipality>> GetMunicipality(int id)
        {
            var municipality = await _context.Municipality.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return municipality;
        }

        // PUT: api/Municipalities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipality(int id, Municipality municipality)
        {
            if (id != municipality.ID)
            {
                return BadRequest();
            }

            _context.Entry(municipality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalityExists(id))
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

        // POST: api/Municipalities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<List<Municipality>>> PostMunicipality(List<Municipality> municipalities)
        {
            // Remove previous approvals
            _context.Municipality.RemoveRange(_context.Municipality);
            await _context.SaveChangesAsync();

            // Add approvals
            _context.Municipality.AddRange(municipalities);
            await _context.SaveChangesAsync();

            return municipalities;
        }

        // DELETE: api/Municipalities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Municipality>> DeleteMunicipality(int id)
        {
            var municipality = await _context.Municipality.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }

            _context.Municipality.Remove(municipality);
            await _context.SaveChangesAsync();

            return municipality;
        }

        private bool MunicipalityExists(int id)
        {
            return _context.Municipality.Any(e => e.ID == id);
        }
    }
}
