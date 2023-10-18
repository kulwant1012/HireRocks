using System.ComponentModel.DataAnnotations;
using PS.ActivityManagementStudio.Helpers;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class ActivityToolModel : ValidableObject
    {
        public string ID { get; set; }

        private string _toolName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ToolName
        {
            get { return _toolName; }
            set { SetPropertyAndValidate(() => _toolName, x => _toolName = x, value); }
        }

        private string _toolDescription { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ToolDescription
        {
            get { return _toolDescription; }
            set { SetPropertyAndValidate(() => _toolDescription, x => _toolDescription = x, value); }
        }
    }
}