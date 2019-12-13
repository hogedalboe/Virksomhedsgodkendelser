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

        [Display(Name = "CVR-nr.")]
        public string CVRnr { get; set; } // Can be string instead of int due to exceptional cases

        [Display(Name = "P-nr.")]
        public string Pnr { get; set; } // Can be string instead of int due to exceptional cases

        [Display(Name = "Virksomhed")]
        public string Pname { get; set; } //******

        [Display(Name = "Adresse")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postnr.")]
        public int PostalCode { get; set; } //******

        [Display(Name = "By")]
        public string City { get; set; } //******

        public int EducationCode { get; set; }

        [Display(Name = "Uddannelse")]
        public string EducationName { get; set; } //******

        public int SpecialisationCode { get; set; }

        [Display(Name = "Speciale")]
        public string SpecialisationName { get; set; } //******

        public string Limitation1 { get; set; }

        public string Limitation2 { get; set; }

        public DateTime ApprovalCreatedDate { get; set; }

        [Display(Name = "Godkendelsesdato")]
        public DateTime ApprovalDate { get; set; } //******

        [Display(Name = "Antal")]
        public int ApprovalQuantity { get; set; } //******

        public int ApprovalsInUse { get; set; }

        public int OtherApprovalsInUse { get; set; }

        public bool Active { get; set; }

        public int RegionCode { get; set; }

        public int MunicipalCode { get; set; }

        public string BusinessCode { get; set; } // Can be string instead of int due to exceptional cases

        public string BusinessName { get; set; }

        // Data about when the approval was uploaded, and by whom
        public string UpdateInitials { get; set; }
        public DateTime UpdateDate { get; set; }


        // Move company data to company model
        //
        //
        //
        //
        //
        //
        //
        //
        //

        public string CorporateStructureCode { get; set; } // Can be string instead of int due to exceptional cases

        public string CorporateStructureName { get; set; }

        public string Website { get; set; }

        public string CompanyStatus { get; set; }

    }
}
