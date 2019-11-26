using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Virksomhedsgodkendelser.Models
{
    public class Approval
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int SpecialisationID { get; set; }

    }
}
