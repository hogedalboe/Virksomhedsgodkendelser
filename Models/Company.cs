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



        [Display(Name = "Postnummer og by")]
        public string PostnrPostdistrikt { get; set; }

        [Display(Name = "Telefonnummer")]
        public string Tlfnr { get; set; }

        [Display(Name = "Uddannelse")]
        public string UddannelseskodeUddannelsesbetegnelse { get; set; }

        [Display(Name = "CØSA")]
        public string COSAnr { get; set; }

        [Display(Name = "Speciale")]
        public string SpecialekodeSpecialebetegnelse { get; set; }

        [Display(Name = "Godkendelse oprettet")]
        public DateTime GodkendelseOprettet { get; set; }

        [Display(Name = "Nygodkendelse")]
        public int Nygodkendelse { get; set; }

        [Display(Name = "Godkendelsesdato")]
        public DateTime Godkendelsesdato { get; set; }

        [Display(Name = "Godkendelsesændring")]
        public int Godkendelsesaendring { get; set; }

        [Display(Name = "Godkendelsesantal")]
        public int Godkendelsesantal { get; set; }

        [Display(Name = "Antal igangværende aftaler")]
        public int AntalIgangvarendeAftaler { get; set; }
        
    }
}
