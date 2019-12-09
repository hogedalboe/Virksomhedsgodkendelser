using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virksomhedsgodkendelser.Models
{
    public class District
    {
        public int ID { get; set; }

        public int DistrictCode { get; set; }

        public string DistrictName { get; set; }

        public int MunicipalityCode { get; set; } // Foreign key
    }
}
