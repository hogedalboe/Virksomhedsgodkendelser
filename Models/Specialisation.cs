using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virksomhedsgodkendelser.Models
{
    public class Specialisation
    {
        public int ID { get; set; }

        public string SpecialisationCode { get; set; }

        public string SpecialisationName { get; set; }

        public string EducationCode { get; set; } // FK
    }
}
