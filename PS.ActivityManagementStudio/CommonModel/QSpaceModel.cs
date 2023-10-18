using System;
using System.ComponentModel.DataAnnotations;
using PS.ActivityManagementStudio.Helpers;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class QSpaceModel : ValidableObject
    {
        public string Id { get; set; }

        private string _qSpaceName { get; set; }

        [Required(ErrorMessage = "QSpace name is required")]
        public string QSpaceName
        {
            get { return _qSpaceName; }
            set { SetPropertyAndValidate(() => _qSpaceName, x => _qSpaceName = x, value); }
        }

        public string Description { get; set; }

        private DateTime _startDate { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetPropertyAndValidate(() => _startDate, x => _startDate = x, value); }
        }

        private DateTime _dueDate { get; set; }

        [Required(ErrorMessage = "Due-date is required")]
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { SetPropertyAndValidate(() => _dueDate, x => _dueDate = x, value); }
        }

        public bool IsActive { get; set; }

        public string ParentQSpaceId { get; set; }

        private string _qspaceType { get; set; }

        [Required(ErrorMessage = "QSpace type is required")]
        public string QSpaceType
        {
            get { return _qspaceType; }
            set { SetPropertyAndValidate(() => _qspaceType, x => _qspaceType = x, value); }
        }

        public int? OTNQSpaceId { get; set; }
    }
}