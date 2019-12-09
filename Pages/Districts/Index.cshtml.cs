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
    public class IndexModel : PageModel
    {
        private readonly Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext _context;

        public IndexModel(Virksomhedsgodkendelser.Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public IList<District> District { get;set; }

        public async Task OnGetAsync()
        {
            District = await _context.District.ToListAsync();
        }
    }
}
