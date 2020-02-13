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
    public class ApprovalsController : ControllerBase
    {
        private readonly VirksomhedsgodkendelserContext _context;

        public ApprovalsController(VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        // GET: api/Approvals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Approval>>> GetApproval()
        {
            return await _context.Approval.ToListAsync();
        }

        // GET: api/Approvals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Approval>> GetApproval(int id)
        {
            var approval = await _context.Approval.FindAsync(id);

            if (approval == null)
            {
                return NotFound();
            }

            return approval;
        }

        // PUT: api/Approvals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApproval(int id, Approval approval)
        {
            if (id != approval.ID)
            {
                return BadRequest();
            }

            _context.Entry(approval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovalExists(id))
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

        // POST: api/Approvals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<List<Approval>>> PostApproval(List<Approval> approvals)
        {
            // Remove previous approvals
            /*
            _context.Approval.RemoveRange(_context.Approval);
            await _context.SaveChangesAsync();
            */

            // Remove dublicate approvals (EXTREMELY INEFFICIENT. RE-WRITE AT LATER STAGE!)
            List<Approval> duplicates = new List<Approval>();
            foreach (Approval dbApproval in _context.Approval)
            {
                foreach (Approval approval in approvals)
                {
                    if (dbApproval.Pnr == approval.Pnr && 
                        dbApproval.EducationCode == approval.EducationCode &&
                        dbApproval.SpecialisationCode == approval.SpecialisationCode)
                    {
                        duplicates.Add(dbApproval);
                    }
                }
            }
            duplicates.ForEach(x => _context.Approval.Remove(x));

            // Add approvals
            _context.Approval.AddRange(approvals);
            await _context.SaveChangesAsync();

            // Remove educations and specialisations
            _context.Education.RemoveRange(_context.Education);
            _context.Specialisation.RemoveRange(_context.Specialisation);

            // Add educations and specialisations implicit in the posted approvals
            List<Education> newEducations = (List<Education>)approvals.Select(a => new { a.EducationCode, a.EducationName }).Distinct();
            _context.Education.AddRange(newEducations);
            List<Specialisation> newSpecialisations = (List<Specialisation>)approvals.Select(a => new { a.SpecialisationCode, a.SpecialisationName, a.EducationCode }).Distinct();
            _context.Education.AddRange(newEducations);

            return approvals;
        }

        // DELETE: api/Approvals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Approval>> DeleteApproval(int id)
        {
            var approval = await _context.Approval.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }

            _context.Approval.Remove(approval);
            await _context.SaveChangesAsync();

            return approval;
        }

        private bool ApprovalExists(int id)
        {
            return _context.Approval.Any(e => e.ID == id);
        }
    }
}
