using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinaryGaming.ViewModels
{
    public class ViewModelUserProfile
    {
        
        [Display(Name = "Member Id")]
        public Int32 Id { get; set; }

        [StringLength(128)]
        [Display(Name = "User Id:")]
        public String UserId { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Surname")]
        public String Surname { get; set; }

        [StringLength(30)]
        [Display(Name = "First Given Name")]
        public String FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Middle Given Name")]
        public String MiddleNames { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address 1")]
        public String Address1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Address 2")]
        public String Address2 { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Suburb")]
        public String Suburb { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Postal Code")]
        public String PostCode { get; set; }

        [StringLength(25)]
        [Display(Name = "Home Phone")]
        public String Phone { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email Address")]
        public String Email { get; set; }

        [StringLength(25)]
        [Display(Name = "Mobile Phone")]
        public String Mobile { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public Int32 MembershipTypesId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Discord Name")]
        public String DiscordName { get; set; }

        [Required]
        [Display(Name = "Discord ID")]
        public Int64 DiscordId { get; set; }

        public IEnumerable<SelectListItem> listMembershipTypes { get; set; }

        public ViewModelUserProfile()
        {
        }

        public ViewModelUserProfile( Members r )
        {
            Id = r.Id;
            UserId = r.AspNetUserId;
            Surname = r.Surname;
            FirstName = r.FirstName;
            MiddleNames = r.MiddleNames;
            Address1 = r.Address1;
            Address2 = r.Address2;
            Suburb = r.Suburb;
            State = r.State;
            PostCode = r.Postcode;
            Phone = r.Phone;
            Email = r.Email;
            Mobile = r.Mobile;
            MembershipTypesId = r.MembershipTypesId;
            DiscordName = r.DiscordName;
            DiscordId = r.DiscordId ?? 0;
        }
    }
}