using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;

using PS.Tracker.Helpers;
using PS.Tracker.Model;
using PS.Tracker.Repository;
using System.Net.Http;
using System.Net.Http.Headers;
using PS.HireRocks.Model;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;

namespace PS.Tracker.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Microsoft.AspNet.Identity initialization
        public LoginViewModel()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
            LoginCommand = new RelayCommand(LoginCommandExecute);
            LoginModel = new LoginModel();           
            ServiceLocator.Current.GetInstance<MainViewModel>().IsBackButtonVisible = false;
            ServiceLocator.Current.GetInstance<MainViewModel>().IsTopNavigationVisible = false;
        }

        public LoginViewModel(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        #endregion

        public RelayCommand LoginCommand { get; set; }

        LoginModel _loginModel { get; set; }
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { _loginModel = value; RaisePropertyChanged(() => LoginModel); }
        }

        string _userNameError { get; set; }
        public string UserNameError
        {
            get { return _userNameError; }
            set { _userNameError = value; RaisePropertyChanged(() => UserNameError); }
        }

        string _passwordError { get; set; }
        public string PasswordError
        {
            get { return _passwordError; }
            set { _passwordError = value; RaisePropertyChanged(() => PasswordError); }
        }

        public void LoginCommandExecute()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var mainViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            mainViewModel.IsBusy = true;
            UserNameError = string.Empty;
            PasswordError = string.Empty;
            if (string.IsNullOrEmpty(LoginModel.UserName)) UserNameError = "UserName is required";
            if (string.IsNullOrEmpty(LoginModel.Password)) PasswordError = "Password is required";
            if (!string.IsNullOrEmpty(UserNameError) || !string.IsNullOrEmpty(PasswordError))
            {
                mainViewModel.IsBusy = false;
                return;
            }
            try
            {
                var user = UserManager.Find(LoginModel.UserName, LoginModel.Password);
                if (user != null && user.IsEmailVerified)
                {
                    ApplicationSession.UserId = user.Id;
                    App.Current.Dispatcher.Invoke(() => new NavigationService().NavigateTo(new Uri(PageUrls.ProjectsElementsPageUrl, UriKind.RelativeOrAbsolute)));
                    mainViewModel.IsTopNavigationVisible = true;
                    mainViewModel.FirstName = user.FirstName;
                    mainViewModel.LastName = user.LastName;
                    mainViewModel.ProfilePic = user.ProfilePic;
                    mainViewModel.ProfilePic = string.Format("{0}{1}{2}", ConfigurationManager.AppSettings["ServerPath"], "/UserData/ProfileImages/Thumbnail/", user.ProfilePic);
                    return;
                }
                else if (user != null && !user.IsEmailVerified)
                    UserNameError = "Email not verified yet";
                else if (user == null)
                    UserNameError = "Incorrect username or password";
                mainViewModel.IsBusy = false;
            }
            catch (Exception)
            {
                ServiceLocator.Current.GetInstance<MainViewModel>().IsBusy = false;
            }
        }
    }
}
