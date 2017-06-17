using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinaryGaming.ViewModels
{
    public class ViewModelMembershipTypeNames
    {
        public int IdMembershipType { get; set; }
        public String MembershipType { get; set; }
    }

    public class ViewModelMembershipTypes
    {
        [HiddenInput(DisplayValue = false)]
        public int IdMembershipType { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Membership Type")]
        public String MembershipType { get; set; }


        [Display(Name = "Annual Fee")]
        public Decimal AnnualFee { get; set; }

        [Display(Name = "Payments Per Year")]
        public Int32 ProrataPayments { get; set; }

        public ViewModelMembershipTypes()
        {
            
        }

        public ViewModelMembershipTypes(MembershipTypes r)
        {
            IdMembershipType = r.Id;
            this.MembershipType = r.MembershipType;
            this.AnnualFee = r.AnnualFee ?? 0;
            this.ProrataPayments = r.ProrataPayments ?? 0;
        }
    }
}
