using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Data;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Pages.Approvals
{
    public class DeleteModel : PageModel
    {
        private readonly Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext _context;

        public DeleteModel(Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Approval Approval { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Approval = await _context.Approval.FirstOrDefaultAsync(m => m.ID == id);

            if (Approval == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Approval = await _context.Approval.FindAsync(id);

            if (Approval != null)
            {
                _context.Approval.Remove(Approval);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
