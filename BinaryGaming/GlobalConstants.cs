using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BinaryGaming
{

    public class RoutePaths
    {
        public const String Default = "Default";
    }

    public class HttpRequestSearchParameters
    {
        public const String SearchString = "matchon";
        public const String Status = "status";
        public const String AccessType = "accesstype";
        public const String RequestedPage = "requestedpage";
        public const String RowsPerPage = "rowsperpage";
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