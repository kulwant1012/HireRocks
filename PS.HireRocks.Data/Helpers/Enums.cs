using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Helpers
{
    public enum JobTypeEnum
    {
        Hourly = 1,
        Fixed = 2,
    }

    public enum DegreeTypeEnum
    {
        Bachelor = 1,
        Masters = 2
    }

    public enum ExperienceLevelEnum
    {
        Fresher = 1,
        InterMediate = 2,
        Expert = 3
    }

    public enum TimeUnitsEnum
    {
        Year = 1,
        Month = 2,
        Day = 3,
        Hour = 4,
        Minute = 5,
    }

    public enum ContractEndReasonEnum
    {
        Other = 4
    }

    public enum ContractDenyReasonEnum
    {
        Other = 2
    }
}
