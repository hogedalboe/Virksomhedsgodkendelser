using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Pages
{
    public class VejledningModel : PageModel
    {
        private readonly Data.VirksomhedsgodkendelserContext _context;

        public VejledningModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get; set; }

        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
        }
    }
}