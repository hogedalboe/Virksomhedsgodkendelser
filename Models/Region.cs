using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virksomhedsgodkendelser.Models
{
    public class Region
    {
        public int ID { get; set; }

        public int RegionCode { get; set; }

        public string RegionName { get; set; }
    }

    /*
     * 1081	Region Nordjylland
     * 1082	Region Midtjylland
     * 1083	Region Syddanmark
     * 1084	Region Hovedstaden
     * 1085	Region Sjælland
     */
}