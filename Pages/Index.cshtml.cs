using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.VirksomhedsgodkendelserContext _context;

        public IList<Company> Company { get; set; }

        public IndexModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchParam { get; set; }

        public async Task OnGetAsync(int pageindex = 1, int pagesize = 50, string search = null)
        {
            // Set filters: ~?pageindex=3&pagesize=10&search=novo-nordisk&
            PageIndex = pageindex;
            PageSize = pagesize;
            SearchParam = search;

            // Return only the page-delimited interval of companies
            Company = await _context.Company.ToListAsync();

        }
    }
}
