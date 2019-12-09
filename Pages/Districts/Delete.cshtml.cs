using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Data;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Pages.Districts
{
    public class DeleteModel : PageModel
    {
        private readonly Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext _context;

        public DeleteModel(Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public District District { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            District = await _context.District.FirstOrDefaultAsync(m => m.ID == id);

            if (District == null)
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

            District = await _context.District.FindAsync(id);

            if (District != null)
            {
                _context.District.Remove(District);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
