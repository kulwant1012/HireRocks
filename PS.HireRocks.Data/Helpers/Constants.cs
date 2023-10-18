using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Helpers
{
    public static class RoleConstants
    {
        public const string Supervisor = "Supervisor";
        public const string Client = "Client";
        public const string Worker = "Worker";
    }

    public static class RoleIdConstants
    {
        public const string Supervisor = "1";
        public const string Client = "2";
        public const string Worker = "3";
    }

    public static class JobTypeConstants
    {
        public const string Hourly = "Hourly";
        public const string Fixed = "Fixed";
    }

    public static class DegreeTypeConstants
    {
        public const string Bachelor = "Bachelor";
        public const string Masters = "Masters";
    }

    public static class ExperienceLevelConstants
    {
        public const string Fresher = "Fresher";
        public const string InterMediate = "InterMediate";
        public const string Expert = "Expert";
    }

    public static class TimeUnitsConstants
    {
        public const string Year = "Year";
        public const string Month = "Month";
        public const string Day = "Day";
        public const string Hour = "Hour";
        public const string Minute = "Minute";
       
    }

    public static class GenderConstants
    {
        public const string Male = "Male";
        public const string Female = "Female";
    }

    public static class ContractStatusConstants
    {
        public const int Open = 1;
        public const int Closed = 2;
        public const int Cancel = 3;
        public const int Awaiting = 4;
    }
}
