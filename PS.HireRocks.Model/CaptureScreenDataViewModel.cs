using System.Collections.Generic;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class CaptureScreenDataViewModel
    {
        public string JobTitle { get; set; }
        public IEnumerable<SelectListItem> WorkersList { get; set; }
        public CaptureScreenDataViewModel()
        {
            WorkersList = new List<SelectListItem>();
        }
    }
}
