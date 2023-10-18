using System;
using System.ComponentModel.DataAnnotations;
using PS.ActivityManagementStudio.Helpers;
using PS.ActivityManagementStudio.PSServiceReference;
using System.Collections.ObjectModel;
using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class UserModel : ValidableObject
    {
        public string Id { get; set; }

        private string _firstName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName
        {
            get { return _firstName; }
            set { SetPropertyAndValidate(() => _firstName, x => _firstName = x, value); }
        }

        private string _lastName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName
        {
            get { return _lastName; }
            set { SetPropertyAndValidate(() => _lastName, x => _lastName = x, value); }
        }

        private string _email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email
        {
            get { return _email; }
            set { SetPropertyAndValidate(() => _email, x => _email = x, value); }
        }

        public Boolean UseWindowsAuthentication { get; set; }
        public string WindowsId { get; set; }

        private string _loginId { get; set; }

        [Required(ErrorMessage = "LoginId is required")]
        public string LoginId
        {
            get { return _loginId; }
            set { SetPropertyAndValidate(() => _loginId, x => _loginId = x, value); }
        }

        private string _password { get; set; }

        public string Password
        {
            get { return _password; }
            set { SetPropertyAndValidate(() => _password, x => _password = x, value); }
        }

        private string _roleId { get; set; }

        public string RoleId
        {
            get { return _roleId; }
            set { SetPropertyAndValidate(() => _roleId, x => _roleId = x, value); }
        }

        private bool _isOnline { get; set; }

        public bool IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value; RaisePropertyChanged(() => IsOnline); }
        }

        public Boolean IsActive { get; set; }

        public Boolean IsLocked { get; set; }

        public int? OTNUserId { get; set; }

        public UserRole[] Roles { get; set; }

        ObservableCollection<UserRoleModel> _assignedUserRoles { get; set; }
        public ObservableCollection<UserRoleModel> AssignedUserRoles
        {
            get { return _assignedUserRoles; }
            set { _assignedUserRoles = value; RaisePropertyChanged(() => _assignedUserRoles); }
        }
    }

    public class AttachmentFile
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}