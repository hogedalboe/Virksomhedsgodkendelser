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
        public IList<District> District { get; set; }
        public IList<Approval> Approval { get; set; }

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
        public string[] MunicipalityCodes { get; set; }


        // Focus
        public string CompanyFocus { get; set; } // Use the API to fetch data about individual companies, instead of filling the browser with all 50 of them?
        public int CompanyCount { get; set; }

        public IndexModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(
            int pageindex = 1, 
            int pagesize = 50, 
            string search = "", 
            string regioncodes = "", 
            string municipalitycodes = "")
        {
            // Parametres: ~?pageindex=3&pagesize=10&search=novo-nordisk&regioncodes=1081-1082&municipalitycodes=740-101&

            // This will be irrelevant once approvals are structured in the database. Thereafter, company data should be API-fetched on CompanyFocus.
            Company = await _context.Company.ToListAsync(); ////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Approval data
            Approval = await _context.Approval.ToListAsync();

            // Geographical data
            RegionCodes = regioncodes.Split("-");
            Region = await _context.Region.ToListAsync();
            MunicipalityCodes = municipalitycodes.Split("-"); 
            Municipality = await _context.Municipality.ToListAsync();

            // Filter by region
            if (regioncodes != "")
            {
                string[] arrRegionCodes = regioncodes.Split("-");

                // Remove approvals not in region
                //
                //
                //
                //
                //
                //
                //
                //

                // Show only municipalities in region
                for (int i = Municipality.Count-1; i >= 0; i--)
                {
                    if (!arrRegionCodes.Contains(Municipality[i].RegionCode.ToString()))
                    {
                        Municipality.Remove(Municipality[i]);
                    }
                }
            }

            // Sort by region
            //
            //
            //
            //
            //
            //
            //
            //
            //

            // Filter by municipality
            if (municipalitycodes != "")
            {
                string[] arrMunicipalityCodes = municipalitycodes.Split("-");

                // Remove approvals not in municipality
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

            // Search through every string and substring related to the approval
            SearchParam = search;
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




            /*--------------------- Pagination -------------------------*/ // THIS SHOULD BE THE LAST STEP OF THE MODEL-VIEW LOADING!

            // Determine page and row count from remaining approval items
            PageSize = pagesize;
            PageCount = 10;
            CompanyCount = 234;
            //
            //
            //
            //
            //
            //
            //
            //
            //

            // Default page or requested page
            if (pageindex > 0 && pageindex <= PageCount)
            {
                PageIndex = pageindex;
            }
            else
            {
                PageIndex = 1;
            }

            // Page size and page scope (+/- 5 pages)
            //
            //
            //
            //
            // Remove approvals not on the requested page
            //
            //
            //
            //
            //
            //
            //

            /*----------------------------------------------------------*/
        }
    }
}
