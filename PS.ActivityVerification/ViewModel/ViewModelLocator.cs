using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using System;

namespace PS.ActivityVerification.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            DispatcherHelper.Initialize();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SelectQSpaceViewModel>();
            SimpleIoc.Default.Register<SelectActivityViewModel>();
            SimpleIoc.Default.Register<NotifyIconViewModel>();
            SimpleIoc.Default.Register<SubmitOutputViewModel>();
        }

        public LoginViewModel LoginModel
        {
            get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); }
        }

        public SelectQSpaceViewModel SelectQSpaceModel
        {
            get { return new SelectQSpaceViewModel(); }
        }

        public SelectActivityViewModel SelectActivityModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectActivityViewModel>();
            }
        }

        public NotifyIconViewModel NotifyIconModel
        {
            get { return ServiceLocator.Current.GetInstance<NotifyIconViewModel>(); }
        }
    }
}