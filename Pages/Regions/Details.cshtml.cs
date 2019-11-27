using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Data;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Pages.Regions
{
    public class DetailsModel : PageModel
    {
        private readonly Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext _context;

        public DetailsModel(Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Region = await _context.Region.FirstOrDefaultAsync(m => m.ID == id);

            if (Region == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
