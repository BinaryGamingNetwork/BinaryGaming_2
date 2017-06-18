using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TimesheetPortal.App_Code;

namespace TimesheetPortal.ViewModels
{
    public class ViewModelEmployee
    {
        [HiddenInput]
        [Editable(false)]
        public Int32 idEmployee { get; set; }

        [Editable(false)]
        [DisplayName("Employee:")]
        public String employeeName { get; set; }

        [Editable(false)]
        [DisplayName("Address:")]
        public String employeeAddress { get; set; }

        [Editable(false)]
        [DisplayName("Email Address:")]
        public String employeeEmail { get; set; }

        [Editable(false)]
        [DisplayName("Contact Phone:")]
        public String employeePhone { get; set; }

        public ViewModelEmployee(Employee record)
        {
            idEmployee = record.IdEmployee;
            employeeName = StringTools.FormatName(record.Surname, record.FirstName, record.MiddleNames);
            employeeAddress = StringTools.FormatAddress(record.Address1, record.Address2, record.Suburb, record.State, record.PostCode);
            employeeEmail = record.EmailAddress;
            employeePhone = record.Phone;
        }
    }


    public class ViewModelEmployeeFull
    {
        [Key]
        [Editable(false)]
        [DisplayName("Ref:")]
        public Int32 idEmployee { get; set; }

        [DisplayName("Swissoft Ref:")]
        public Int32 SwissoftId { get; set; }

        [DisplayName("Swissoft Abbrev:")]
        public String SwissoftAbbrev { get; set; }

        [Required]
        [DisplayName("Surname:")]
        public String Surname { get; set; }

        [DisplayName("First Name:")]
        public String FirstName { get; set; }

        [DisplayName("Middle Names :")]
        public String MiddleNames { get; set; }

        [DisplayName("Address1:")]
        public String Address1 { get; set; }

        [DisplayName("Address2:")]
        public String Address2 { get; set; }

        [DisplayName("Suburb:")]
        public String Suburb { get; set; }

        [DisplayName("State:")]
        public String State { get; set; }

        [DisplayName("Postcode:")]
        public String Postcode { get; set; }

        [Required]
        [DisplayName("Status:")]
        public EmployeeStatus Status { get; set; }

        [Required]
        [DisplayName("Email Address:")]
        public String employeeEmail { get; set; }

        [DisplayName("Contact Phone:")]
        public String employeePhone { get; set; }

        [HiddenInput]
        public Int32 IdUser { get; set; }

        public ViewModelEmployeeFull()
        {
        }

        public ViewModelEmployeeFull(Employee record)
        {

            idEmployee = record.IdEmployee;
            SwissoftId = record.IdSwissoft ?? 0;
            SwissoftAbbrev = record.SwissoftAbrev;
            Surname = record.Surname;
            FirstName = record.FirstName;
            MiddleNames = record.MiddleNames;
            Address1 = record.Address1;
            Address2 = record.Address2;
            Suburb = record.Suburb;
            State = record.State;
            Postcode = record.PostCode;
            if (record.Status == Enum.GetName(typeof(EmployeeStatus), EmployeeStatus.Active))
                Status = EmployeeStatus.Active;

            if (record.Status == Enum.GetName(typeof(EmployeeStatus), EmployeeStatus.Disabled))
                Status = EmployeeStatus.Disabled;

            employeeEmail = record.EmailAddress;
            employeePhone = record.Phone;
            IdUser = record.IdUser ?? 0;
        }
    }
}
