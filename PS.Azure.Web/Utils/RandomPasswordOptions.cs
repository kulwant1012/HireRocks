using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Azure.Web.Utils
{
    public enum RandomPasswordOptions
    {
        Alpha = 1,
        Numeric = 2,
        AlphaNumeric = Alpha + Numeric,
        AlphaNumericSpecial = 4
    }

}