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
        public int ApprovalCount { get; set; }
        public IList<Education> Education { get; set; }
        public IList<Specialisation> Specialisation { get; set; }

        // Paging
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int[] PageSizes = new int[5] { 20, 50, 100, 150, 200 };
        public int PageCount { get; set; }

        // Filter and sorting parameters
        public string SearchParam { get; set; }
        public string SortBy { get; set; }
        public bool SortByNormal { get; set; }

        // Geographical parameters
        public string[] RegionCodes { get; set; }
        public string[] MunicipalityCodes { get; set; }

        // Education parameters
        public string[] EducationCodes { get; set; }
        public string[] SpecialisationCodes { get; set; }

        public IndexModel(Data.VirksomhedsgodkendelserContext context)
        {
            _context = context;
        }
        
        public async Task OnGetAsync(
            int pageindex = 1, 
            int pagesize = 50, 
            string search = "", 
            string regioncodes = "", 
            string municipalitycodes = "",
            string educationcodes = "",
            string specialisationcodes = "",
            string sortby = "",
            int sortbynormal = 1)
        {
            // Parameters: ~?pageindex=3&pagesize=10&search=novo-nordisk&regioncodes=1081-1082&municipalitycodes=740-101&

            // Sorting
            SortBy = sortby;
            SortByNormal = Convert.ToBoolean(sortbynormal);
            if (sortby != "")
            {
                // Sorting column with intuitively normal ordering
                if (SortByNormal)
                {
                    switch (sortby)
                    {
                        case "Pname":
                            Approval = await _context.Approval.OrderBy(a => a.Pname).ToListAsync();
                            break;
                        case "City":
                            Approval = await _context.Approval.OrderBy(a => a.City).ToListAsync();
                            break;
                        case "EducationName":
                            Approval = await _context.Approval.OrderBy(a => a.EducationName).ToListAsync();
                            break;
                        case "SpecialisationName":
                            Approval = await _context.Approval.OrderBy(a => a.SpecialisationName).ToListAsync();
                            break;
                        case "ApprovalDate":
                            Approval = await _context.Approval.OrderByDescending(a => a.ApprovalDate).ToListAsync();
                            break;
                        case "ApprovalQuantity":
                            Approval = await _context.Approval.OrderByDescending(a => a.ApprovalQuantity).ToListAsync();
                            break;
                        default:
                            Approval = await _context.Approval.OrderBy(a => a.ID).ToListAsync();
                            sortby = "";
                            break;
                    }
                }
                // Sorting column with reverse ordering
                else
                {
                    switch (sortby)
                    {
                        case "Pname":
                            Approval = await _context.Approval.OrderByDescending(a => a.Pname).ToListAsync();
                            break;
                        case "City":
                            Approval = await _context.Approval.OrderByDescending(a => a.City).ToListAsync();
                            break;
                        case "EducationName":
                            Approval = await _context.Approval.OrderByDescending(a => a.EducationName).ToListAsync();
                            break;
                        case "SpecialisationName":
                            Approval = await _context.Approval.OrderByDescending(a => a.SpecialisationName).ToListAsync();
                            break;
                        case "ApprovalDate":
                            Approval = await _context.Approval.OrderBy(a => a.ApprovalDate).ToListAsync();
                            break;
                        case "ApprovalQuantity":
                            Approval = await _context.Approval.OrderBy(a => a.ApprovalQuantity).ToListAsync();
                            break;
                        default:
                            Approval = await _context.Approval.OrderByDescending(a => a.ID).ToListAsync();
                            sortby = "";
                            break;
                    }
                }
            }
            else
            {
                Approval = await _context.Approval.OrderByDescending(a => a.ApprovalDate).ToListAsync();
                SortBy = "";
            }

            // Education data
            EducationCodes = educationcodes.Split("-");
            Education = await _context.Education.OrderBy(e => e.EducationName).ToListAsync();
            SpecialisationCodes = specialisationcodes.Split("-");
            Specialisation = await _context.Specialisation.OrderBy(s => s.SpecialisationName).ToListAsync();

            // Filter by education
            if (educationcodes != "")
            {
                string[] arrEducationCodes = EducationCodes;

                // Remove approvals not related to education
                foreach (string eduCode in arrEducationCodes)
                {
                    Approval = Approval.Where(a => a.EducationCode == eduCode).ToList();
                }

                // Show only specialisations in selected education
                for (int i = Specialisation.Count - 1; i >= 0; i--)
                {
                    if (!arrEducationCodes.Contains(Specialisation[i].EducationCode))
                    {
                        Specialisation.Remove(Specialisation[i]);
                    }
                }
            }

            // Filter by specialisation
            //
            //
            //
            //
            //
            //
            //

            // Geographical data
            RegionCodes = regioncodes.Split("-");
            Region = await _context.Region.OrderBy(r => r.RegionName).ToListAsync();
            MunicipalityCodes = municipalitycodes.Split("-");
            Municipality = await _context.Municipality.OrderBy(m => m.MunicipalityName).ToListAsync();

            // Filter by region
            if (regioncodes != "")
            {
                string[] arrRegionCodes = RegionCodes;

                // Show only approvals in region
                for (int i = Approval.Count - 1; i >= 0; i--)
                {
                    if (!arrRegionCodes.Contains(Approval[i].RegionCode.ToString()))
                    {
                        Approval.Remove(Approval[i]); 
                        //////////////////////////////////////////// DETTE SKAL IMPLEMENTERES I DE ANDRE FILTRE!
                        /////
                        /////
                        /////
                        /////
                        /////
                        /////
                        /////
                        /////
                        /////
                    }
                }

                // Show only municipalities in region
                for (int i = Municipality.Count-1; i >= 0; i--)
                {
                    if (!arrRegionCodes.Contains(Municipality[i].RegionCode.ToString()))
                    {
                        Municipality.Remove(Municipality[i]);
                    }
                }
            }

            // Filter by municipality
            if (municipalitycodes != "")
            {
                string[] arrMunicipalityCodes = MunicipalityCodes;

                // Remove approvals not in municipality
                foreach (string municipalityCode in arrMunicipalityCodes)
                {
                    Approval = Approval.Where(a => a.MunicipalCode == Convert.ToInt32(municipalitycodes)).ToList();
                }
            }

            // Search through every string and substring related to the approval
            SearchParam = search;
            //
            //
            //
            //
            // THIS SHOULD BE LAST (BUT BEFORE PAGINATION) TO ITERATE AS FEW ITEMS AS POSSIBLE!
            //
            //
            //
            //
            //




            /*--------------------- Pagination -------------------------*/ // THIS SHOULD BE THE LAST STEP OF THE MODEL-VIEW LOADING!

            // Determine page and row count from remaining approval items
            if (pagesize <= PageSizes.Last())
            {
                PageSize = pagesize;
            }
            else
            {
                PageSize = PageSizes.Last();
            }
            ApprovalCount = Approval.Count;
            PageCount = (int)((float)ApprovalCount / PageSize + 0.5f);

            // Default page or requested page
            if (pageindex > 0 && pageindex <= PageCount)
            {
                PageIndex = pageindex;
            }
            else
            {
                PageIndex = 1;
            }

            // Return only page delimited approvals to view
            Approval = Approval.Skip((PageIndex * PageSize) - PageSize).Take(PageSize).ToList();

            //
            //
            //
            //
            //
            //
            //
            //
            //



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
