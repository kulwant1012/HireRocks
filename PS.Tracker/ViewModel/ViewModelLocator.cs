/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PS.Tracker"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PS.Tracker.Helpers;

namespace PS.Tracker.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FancyBaloonViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return new LoginViewModel();
            }
        }

        public JobViewModel ProjectsViewModel
        {
            get
            {
                return new JobViewModel();
            }
        }

        public JobViewModel ProjectElementViewModel
        {
            get
            {
                return new JobViewModel();
            }
        }

        public FancyBaloonViewModel FancyBaloonViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FancyBaloonViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}