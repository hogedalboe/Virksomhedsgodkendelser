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

        // Data
        public IList<Company> Company { get; set; }
        public IList<Region> Region { get; set; }
        public IList<Municipality> Municipality { get; set; }

        // Paging
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int[] PageSizes = new int[5] { 20, 50, 100, 150, 200 };
        public int PageCount { get; set; }

        // Filter and sorting parameters
        public string SearchParam { get; set; }
        public string SortParam { get; set; }

        // Geographical parameters
        public string[] RegionCodes { get; set; }

        // Filter data 
        //public string[] Regions ...
        //public string[] Municipalities ...
        //public string[] Educations ...
        //public string[] Specialisations ...

        // Focus
        public string CompanyFocus { get; set; } // Use the API to fetch data about individual companies, instead of filling the browser with all 50 of them?
        public int CompanyCount { get; set; }

        public IndexModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int pageindex = 1, int pagesize = 50, string search = "", string regioncodes = "")
        {
            // Return only the page-delimited interval of companies
            Company = await _context.Company.ToListAsync();

            // Determine page and row count from data
            PageCount = 10;
            CompanyCount = 234;

            // Set parametres: ~?pageindex=3&pagesize=10&search=novo-nordisk&region=1081-1082&

            // Page range
            if (pageindex > 0 && pageindex <= PageCount)
            {
                PageIndex = pageindex;
            }
            else
            {
                PageIndex = 1;
            }
            
            // Page size

            PageSize = pagesize;
            SearchParam = search;

            // Geographical data
            RegionCodes = regioncodes.Split("-"); // Used to initialize checked status on input element
            Region = await _context.Region.ToListAsync();

            Municipality = await _context.Municipality.ToListAsync();
            List<Municipality> toKeepMunicipality = new List<Municipality>();

            // Sort by region
            if (regioncodes != "")
            {
                string[] arrRegionCodes = regioncodes.Split("-");

                // Get only approvals in region
                //
                //
                //
                //
                //
                //
                //
                //

                // Show only municipalities in region
                foreach (string strRegionCode in arrRegionCodes)
                {
                    for (int i = 0; i < Municipality.Count; i++)
                    {
                        if (Municipality[i].RegionCode == Convert.ToInt32(strRegionCode))
                        {
                            toKeepMunicipality.Add(Municipality[i]);
                        }
                    }
                }
                Municipality = toKeepMunicipality;
            }

            // Sort by municipality
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //
        }
    }
}
