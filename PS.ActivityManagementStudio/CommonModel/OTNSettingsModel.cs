using System.ComponentModel.DataAnnotations;
using PS.ActivityManagementStudio.Helpers;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class OTNSettingsModel : ValidableObject
    {
        private string _otnURL { get; set; }

        [Required(ErrorMessage = "Required")]
        public string OTNURL
        {
            get { return _otnURL; }
            set { SetPropertyAndValidate(() => _otnURL, x => _otnURL = x, value); }
        }

        private string _clientId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ClientId
        {
            get { return _clientId; }
            set { SetPropertyAndValidate(() => _clientId, x => _clientId = x, value); }
        }

        private string _clietSecret { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ClietSecret
        {
            get { return _clietSecret; }
            set { SetPropertyAndValidate(() => _clietSecret, x => _clietSecret = x, value); }
        }
    }
}