using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetPortal
{
    public class SessionField
    {
        public const String AuthenticatedYN = "AuthenticatedYN";
        public const String IdUser = "IdUser";
        public const String AdminYN = "AdminYN";
        public const String ApproveTimesheetsYN = "ApproveTimesheetsYN";
        public const String EnterOwnTimesheetsYN = "EnterOwnTimesheets";
        public const String TimesheetsIdEmployee = "TimesheetsIdEmployee";
        public const String TimesheetsIdClient = "TimesheetsIdClient";

    }

    public class RoutePaths
    {
        public const String Default = "Default";
        public const String WithContext = "WithContext";
    }

    public class ControllerNames
    {
        public const String Timesheets = "Timesheets";
    }

    public class ActionMethodNames
    {
        public const String MyEmployeeTimesheetEdit = "MyEmployeeTimesheetEdit";
        public const String ClientReviewDetail = "ClientReviewDetail";
    }

    public class PlacementStatusValues
    {
        public const String Active = "Active";
        public const String Completed = "Completed";
    }

    public class TimesheetStatusValues
    {
        public const String All = "All";
        public const String Draft = "Draft";
        public const String Submitted = "Submitted";
        public const String Approved = "Approved";
        public const String Void = "Void";
    }

    public class SecurityRoles
    {
        public const String All = "All";   // Only used as a means of viewing all the roles via code
        public const String Administration = "Administration";
        public const String ApproveTimesheets = "ApproveTimesheets";
        public const String EnterOwnTimesheets = "EnterOwnTimesheets";
        public const String Guest = "Guest";

    }


    public enum EmployeeStatus
    {
        Active, Disabled
    }

    public enum ClientContactStatus
    {
        Active, Disabled
    }

    public class HttpRequestSearchParameters
    {
        public const String SearchString = "matchon";
        public const String Status = "status";
        public const String AccessType = "accesstype";
        public const String RequestedPage = "requestedpage";
        public const String RowsPerPage = "rowsperpage";
    }

    public class HttpRequestJobTagParameters
    {
        public const String IdContact = "idcontact";
        public const String IdJob = "idjob";
    }

    public class HttpResponseJobTagActions
    {
        public const String Tag = "Action Tag";
        public const String Untag = "Action Untag";
    }

    public class WeekDays
    {
        public const String Sunday = "Sunday";
        public const String Monday = "Monday";
        public const String Tuesday = "Tuesday";
        public const String Wednesday = "Wednesday";
        public const String Thursday = "Thursday";
        public const String Friday = "Friday";
        public const String Saturday = "Saturday";
    }

    public enum EmailContentType { Text, Html }

}

