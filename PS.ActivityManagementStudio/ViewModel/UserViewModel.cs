using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Windows;
using System.Windows.Threading;
using PS.ActivityManagementStudio.CommonModel;
using PS.ActivityManagementStudio.PSServiceReference;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNet.SignalR.Client;
using System.Configuration;
using System.Collections.Generic;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private readonly DispatcherTimer _updateTimer = new DispatcherTimer();

        public RelayCommand<UserModel> OpenEditUserCommand { get; set; }
        public ObservableCollection<UserRoleModel> Roles { get; set; }

        public RelayCommand OpenAddUserCommand { get; set; }
        public RelayCommand AddUserCommand { get; set; }

        private ObservableCollection<UserModel> _userList { get; set; }

        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set
            {
                if (_userList != value)
                {
                    _userList = value;
                    RaisePropertyChanged(() => UserList);
                }
            }
        }

        private UserModel _userModel { get; set; }

        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                if (_userModel != value)
                {
                    _userModel = value;
                    RaisePropertyChanged(() => UserModel);
                }
            }
        }

        private string _windowTitle { get; set; }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    RaisePropertyChanged(() => WindowTitle);
                }
            }
        }

        private string _buttonText { get; set; }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                if (_buttonText != value)
                {
                    _buttonText = value;
                    RaisePropertyChanged(() => ButtonText);
                }
            }
        }

        private bool _isAddNewUser { get; set; }

        public bool IsAddNewUser
        {
            get { return _isAddNewUser; }
            set
            {
                if (_isAddNewUser != value)
                {
                    _isAddNewUser = value;
                    RaisePropertyChanged(() => IsAddNewUser);
                }
            }
        }

        private bool _isUserListVisible { get; set; }

        public bool IsUserListVisible
        {
            get { return _isUserListVisible; }
            set
            {
                if (_isUserListVisible != value)
                {
                    _isUserListVisible = value;
                    RaisePropertyChanged(() => IsUserListVisible);
                }
            }
        }

        public UserViewModel()
        {
            if (IsInDesignMode)
            {
                return;
            }
            try
            {
                Roles = new ObservableCollection<UserRoleModel>();
                Roles.Add(new UserRoleModel { Name = "User", Role = UserRole.User });
                Roles.Add(new UserRoleModel { Name = "Manager", Role = UserRole.Manager });
                IsBusy = true;
                OpenEditUserCommand = new RelayCommand<UserModel>(OpenEditUserScreen);
                OpenAddUserCommand = new RelayCommand(OpenAddUserScreen);
                AddUserCommand = new RelayCommand(AddUserExecute);
                GetViewData();               
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void GetViewData()
        {
            try
            {
                var users = await ActivityOptimizationSystemServiceClient.GetUserAsync();
                if (!users.IsErrorReturned)
                {
                    ParallelQuery<UserModel> userList = (from user in users.Value
                                                         select new UserModel
                                                         {
                                                             Id = user.Id,
                                                             FirstName = user.FirstName,
                                                             LastName = user.LastName,
                                                             Email = user.Email,
                                                             IsActive = user.IsActive,
                                                             IsLocked = user.IsLocked,
                                                             LoginId = user.Login,
                                                             Password = user.Password,
                                                             OTNUserId = user.OTNUserId,
                                                             RoleId = user.Roles != null ? ((UserRole)user.Roles.Max(i => Convert.ToInt32(i))).ToString() : "Empty",
                                                             Roles = user.Roles,
                                                             AssignedUserRoles = new ObservableCollection<UserRoleModel>(from role in user.Roles select new UserRoleModel { Name = role.ToString(), Role = role })
                                                         }).AsParallel();

                    UserList = new ObservableCollection<UserModel>(userList);                   
                    if (UserList.Count > 0)
                        IsUserListVisible = true;
                    else
                        IsUserListVisible = false;
                }
                _notificationHub.On<string>("SendConnectedMessage", SendConnectedMessage);
                _notificationHub.On<string>("SendDisconnectedMessage", SendDisconnectedMessage);
                _notificationHub.On<List<string>>("GetConnectedClients", GetConnectedClients);
                await _notificationHub.Invoke("GetOnlineUsers");
            }
            catch (Exception ex)
            {
                IsBusy = false;
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private async void AddUserExecute()
        {
            try
            {
                Message = string.Empty;
                if (UserModel.ValidateObject())
                {
                    if (string.IsNullOrEmpty(UserModel.Password))
                    {
                        Message = "Password is required";
                        return;
                    }
                    var roles = Roles.Where(i => i.IsChecked).Select(o => o.Role).ToArray();
                    if (roles.Count()==0)
                    {
                        Message = "Please assign role to user";
                        return;
                    }
                    IsBusy = true;
                    var acsUser = new User();
                    acsUser.Id = UserModel.Id;
                    acsUser.FirstName = UserModel.FirstName;
                    acsUser.LastName = UserModel.LastName;
                    acsUser.Email = UserModel.Email;
                    acsUser.Login = UserModel.LoginId;
                    acsUser.Password = UserModel.Password;
                    acsUser.IsActive = true;
                    acsUser.IsLocked = false;
                    acsUser.Roles = roles;

                    var result = await ActivityOptimizationSystemServiceClient.AddOrUpdateUserAsync(acsUser);
                    if (!result.IsErrorReturned)
                    {
                        UserModel.AssignedUserRoles = new ObservableCollection<UserRoleModel>(Roles.Where(x => x.IsChecked));
                        UserModel.Roles = roles;
                        string message = string.Empty;
                        string subject = string.Empty;
                        string to = UserModel.Email;
                        if (IsAddNewUser)
                        {
                            subject = "Welcome to PS";
                            UserModel.Id = result.Value.Id;
                            UserList.Add(UserModel);
                            UserModel = new UserModel();
                            Roles.ToList().ForEach(x => x.IsChecked = false);
                            Message = "User added successfully";
                        }
                        else
                        {
                            //UserList.FirstOrDefault(x => x.Id == UserModel.Id).SecurityRoles = GetAssignedSecurityRoles(UserModel.SecurityRoles.Select(x => x.Id).ToArray());
                            ObservableCollection<UserModel> userList = UserList;
                            UserList = new ObservableCollection<UserModel>(userList);
                            subject = "Account updated on PS";
                            Message = "User updated successfully";
                        }

                        IsBusy = false;
                        using (var smtpClient = new SmtpClient())
                        {
                            var emailTemplate = await ActivityOptimizationSystemServiceClient.GetEmailTemplateByIdAsync("NewUserEmailTemplate");
                            string template = emailTemplate.Value.TemplateBody;
                            template = template.Replace("#Name#", acsUser.Login);
                            template = template.Replace("#Password#", acsUser.Password);
                            if (IsAddNewUser)
                                template = template.Replace("#Message#", "Thank you for Registering with PS");
                            else
                                template = template.Replace("#Message#", "Recently your account updated on PS");
                            var mailMessage = new MailMessage();
                            mailMessage.Body = template;
                            mailMessage.IsBodyHtml = true;
                            mailMessage.Subject = subject;
                            mailMessage.To.Add(to);
                            await smtpClient.SendMailAsync(mailMessage);
                        }
                    }
                    else
                        MessageBox.Show(result.ErrorMessage);
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        private void OpenEditUserScreen(UserModel userModel)
        {
            try
            {
                Message = string.Empty;
                IsAddNewUser = false;
                WindowTitle = "Edit user information";
                ButtonText = "Update user";
                UserModel = userModel;
                Roles = new ObservableCollection<UserRoleModel>();
                Roles.Add(new UserRoleModel {Name = "User", Role = UserRole.User});
                Roles.Add(new UserRoleModel {Name = "Manager", Role = UserRole.Manager});
                Roles.ToList().ForEach(x => x.IsChecked = false);
                if (userModel.Roles != null)
                {
                    foreach (UserRole userRole in userModel.Roles)
                    {
                        foreach (UserRoleModel userRoleModel in Roles)
                        {
                            if (userRole == userRoleModel.Role)
                            {
                                userRoleModel.IsChecked = true;
                            }
                        }
                    }
                }
                Messenger.Default.Send(new AddUpdateUserWindowMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        private void OpenAddUserScreen()
        {
            try
            {
                Message = string.Empty;
                IsAddNewUser = true;
                WindowTitle = "Add user";
                ButtonText = "Add user";
                UserModel = new UserModel();
                Roles.ToList().ForEach(x => x.IsChecked = false);
                Messenger.Default.Send(new AddUpdateUserWindowMessage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\r" + "More details: " + ex);
            }
        }

        void SendConnectedMessage(string userId)
        {
            var userInfo = UserList.FirstOrDefault(x => x.Id == userId);
            if (userInfo != null)
                userInfo.IsOnline = true;
        }

        void SendDisconnectedMessage(string userId)
        {
            var userInfo = UserList.FirstOrDefault(x => x.Id == userId);
            if (userInfo != null)
                userInfo.IsOnline = false;
        }

        void GetConnectedClients(List<string> userIds)
        {
            UserList.Where(x => userIds.Contains(x.Id)).ToList().ForEach(x => x.IsOnline = true);
        }
    }

    public class UserRoleModel : ViewModelBase
    {
        private bool _isChecked;
        public UserRole Role { get; set; }
        public string Name { get; set; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged(() => IsChecked);
            }
        }
    }
}