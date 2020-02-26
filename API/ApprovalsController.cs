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
            // Check for duplicate approvals
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

            // Get distinct specialisations from approvals
            List<Approval> distinctSpecs = new List<Approval>();
            distinctSpecs.AddRange(approvals.GroupBy(a => a.SpecialisationName).Select(group => group.First()));
            foreach (Approval distinctSpec in distinctSpecs)
            {
                // Check for duplicate specialisations
                bool duplicateSpec = false;
                foreach (Specialisation spec in _context.Specialisation)
                {
                    if (distinctSpec.SpecialisationName == spec.SpecialisationName)
                    {
                        duplicateSpec = true;
                        break;
                    }
                }

                if (!duplicateSpec)
                {
                    // Add to specialisation model
                    _context.Specialisation.Add(
                        new Specialisation 
                        { 
                            SpecialisationCode = distinctSpec.SpecialisationCode, 
                            SpecialisationName = distinctSpec.SpecialisationName,
                            EducationCode = distinctSpec.EducationCode
                        });
                }
            }

            // Get distinct educations from approvals
            List<Approval> distinctEdus = new List<Approval>();
            distinctEdus.AddRange(approvals.GroupBy(a => a.EducationName).Select(group => group.First()));
            foreach (Approval distinctEdu in distinctEdus)
            {
                // Check for duplicate educations
                bool duplicateEdu = false;
                foreach (Education edu in _context.Education)
                {
                    if (distinctEdu.EducationName == edu.EducationName)
                    {
                        duplicateEdu = true;
                        break;
                    }
                }

                if (!duplicateEdu)
                {
                    // Add to education model
                    _context.Education.Add(
                        new Education
                        {
                            EducationCode = distinctEdu.EducationCode,
                            EducationName = distinctEdu.EducationName
                        });
                }
            }

            await _context.SaveChangesAsync();

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
