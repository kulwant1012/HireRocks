using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PS.HireRocks.Data.Helpers
{
    public class GetCountriesAndTimeZone
    {
        public static IEnumerable<SelectListItem> GetCountriesList()
        {
            List<SelectListItem> countriesList = new List<SelectListItem>();
            SelectListItem country;
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo regionInfo = new RegionInfo(culture.LCID);
                country = new SelectListItem { Text = regionInfo.EnglishName, Value = regionInfo.EnglishName };
                if (!countriesList.Exists(x => x.Value == country.Value))
                    countriesList.Add(country);
            }
            return countriesList.OrderBy(x => x.Value);
        }

        public static IEnumerable<SelectListItem> GetTimeZoneList()
        {
            return from timeZone in TimeZoneInfo.GetSystemTimeZones() select new SelectListItem { Text = timeZone.DisplayName, Value = timeZone.DisplayName };
        }
    }
}
