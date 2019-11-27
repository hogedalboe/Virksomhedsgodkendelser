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
        public string RegionName { get; set; }
    }
}