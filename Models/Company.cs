using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Virksomhedsgodkendelser.Models
{
    public class Company
    {
        public int ID { get; set; }
        public int Pnr { get; set; }
        public string Virksomhedsnavn { get; set; }

        [DataType(DataType.Date)]
        public string CVRnr { get; set; }
        public string Adresse { get; set; }
        public string PostnrPostdistrikt { get; set; }
        public string Tlfnr { get; set; }
        public string UddannelseskodeUddannelsesbetegnelse { get; set; }
        public string COSAnr { get; set; }
        public string SpecialekodeSpecialebetegnelse { get; set; }
        public DateTime GodkendelseOprettet { get; set; }
        public int Nygodkendelse { get; set; }
        public DateTime Godkendelsesdato { get; set; }
        public int Godkendelsesaendring { get; set; }
        public int Godkendelsesantal { get; set; }
        public int AntalIgangvarendeAftaler { get; set; }

    }
}
