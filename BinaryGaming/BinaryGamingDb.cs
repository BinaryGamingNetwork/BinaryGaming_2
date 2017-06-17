using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BinaryGaming.Models;
using BinaryGaming.ViewModels;
using System.Globalization;

namespace BinaryGaming
{
    public partial class Members
    {
        /*
         * While the statistical information like DateJOined etc are set to default values it is assumed that the new record will be added 
         * to the database and not be used tooverwrite an existing record.  The ModelMembers.Update method calls Members.Assign() to move
         * Member record data to a record just retrieved from the database and then writing it back.  In this way statistical information
         * is not overwritten inadvertently.  The intent is to have special functions in ModelMembers that can be called to specifically
         * update the statistical information.
         */
        public Members(ViewModelUserProfile vmRecord)
        {
            Id = vmRecord.Id;
            Surname = vmRecord.Surname;
            FirstName = vmRecord.FirstName;
            MiddleNames = vmRecord.MiddleNames;
            Address1 = vmRecord.Address1;
            Address2 = vmRecord.Address2;
            Suburb = vmRecord.Suburb;
            State = vmRecord.State;
            Postcode = vmRecord.PostCode;
            Phone = vmRecord.Phone;
            Email = vmRecord.Email;
            Mobile = vmRecord.Mobile;
            MembershipTypesId = Int32.Parse(vmRecord.MembershipTypesId.ToString());
            DiscordName = vmRecord.DiscordName;
            DiscordId = vmRecord.DiscordId;
            AspNetUserId = vmRecord.UserId;
            DateJoined = DateTime.Today;
            FinancialYN = false;
            MembershipExpiry = DateTime.ParseExact("01/01/2000", "d/M/yyyy", CultureInfo.InvariantCulture);
            LastLoggedIn = DateTime.ParseExact("01/01/2000", "d/M/yyyy", CultureInfo.InvariantCulture);
        }

        public void Assign(Members r)
        {
            Surname = r.Surname;
            FirstName = r.FirstName;
            MiddleNames = r.MiddleNames;
            Address1 = r.Address1;
            Address2 = r.Address2;
            Suburb = r.Suburb;
            State = r.State;
            Postcode = r.Postcode;
            Phone = r.Phone;
            Email = r.Email;
            Mobile = r.Mobile;
            MembershipTypesId = r.MembershipTypesId;
            DiscordName = r.DiscordName;
            DiscordId = r.DiscordId;
            AspNetUserId = r.AspNetUserId;
        }
    }
}
