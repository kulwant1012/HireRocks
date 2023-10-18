using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class ViewModelLocator : BaseViewModel
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            DispatcherHelper.Initialize();

            SimpleIoc.Default.Register<ActivityVerificationViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<QSpaceViewModel>();
            SimpleIoc.Default.Register<ActivityViewModel>();
            SimpleIoc.Default.Register<AddDictionaryViewModel>();
            SimpleIoc.Default.Register<DictionaryViewModel>();
            SimpleIoc.Default.Register<ActivityToolViewModel>();
            SimpleIoc.Default.Register<ReportsViewModel>();
        }

        public ActivityVerificationViewModel ActivityVerificationModel
        {
            get { return new ActivityVerificationViewModel(); }
        }

        public LoginViewModel LoginModel
        {
            get { return new LoginViewModel(); }
        }

        public MainWindowViewModel MainWindowModel
        {
            get { return new MainWindowViewModel(); }
        }

        public UserViewModel UserViewModel
        {
            get { return ServiceLocator.Current.GetInstance<UserViewModel>(); }
        }

        public QSpaceViewModel QSpaceViewModel
        {
            get
            {
                if (IsAddUpdateView)
                    return ServiceLocator.Current.GetInstance<QSpaceViewModel>();
                ((IDisposable) ServiceLocator.Current.GetAllInstances<QSpaceViewModel>()).Dispose();
                return ServiceLocator.Current.GetInstance<QSpaceViewModel>();
            }
        }

        public ActivityViewModel ActivityViewModel
        {
            get
            {
                if (!IsAddUpdateView)
                {
                    ((IDisposable) ServiceLocator.Current.GetAllInstances<ActivityViewModel>()).Dispose();
                    SimpleIoc.Default.Unregister<ActivityViewModel>();
                    SimpleIoc.Default.Register<ActivityViewModel>();
                }

                IsAddUpdateView = false;
                return ServiceLocator.Current.GetInstance<ActivityViewModel>();
            }
        }

        public DictionaryViewModel DictionaryModel
        {
            get { return ServiceLocator.Current.GetInstance<DictionaryViewModel>(); }
        }

        public AddDictionaryViewModel AddDictionaryModel
        {
            get { return ServiceLocator.Current.GetInstance<AddDictionaryViewModel>(); }
        }

        public ActivityToolViewModel ActivityToolViewModel
        {
            get { return ServiceLocator.Current.GetInstance<ActivityToolViewModel>(); }
        }

        public ReportsViewModel ReportsViewModel
        {
            get { return new ReportsViewModel(); }
        }
    }
}