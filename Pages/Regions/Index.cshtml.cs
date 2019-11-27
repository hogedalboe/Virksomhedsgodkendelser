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
    public class IndexModel : PageModel
    {
        private readonly Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext _context;

        public IndexModel(Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public IList<Region> Region { get;set; }

        public async Task OnGetAsync()
        {
            Region = await _context.Region.ToListAsync();
        }
    }
}
