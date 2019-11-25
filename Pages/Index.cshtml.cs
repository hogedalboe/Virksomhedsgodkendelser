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

        // Filter parameters
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchParam { get; set; }

        // Filter data 
        //public string[] Regions ...
        //public string[] Municipalities ...
        //public string[] Educations ...
        //public string[] Specialisations ...

        public IndexModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int pageindex = 1, int pagesize = 50, string search = "")
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
