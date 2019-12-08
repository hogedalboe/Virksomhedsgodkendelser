using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virksomhedsgodkendelser.Models
{
    public class Municipality
    {
        public int ID { get; set; }

        public int MunicipalityCode { get; set; }

        public string MunicipalityName { get; set; }

        public int RegionCode { get; set; } // Foreign key
    }
}
