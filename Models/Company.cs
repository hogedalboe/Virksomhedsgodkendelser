using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virksomhedsgodkendelser.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Display(Name = "P-nr")]
        public int Pnr { get; set; }

        public string Virksomhedsnavn { get; set; }
        
        [Display(Name = "CVR-nr")]
        public string CVRnr { get; set; }
    }
}
