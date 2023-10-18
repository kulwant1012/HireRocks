using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace PS.ActivityManagementStudio.View
{
    /// <summary>
    /// Interaction logic for ActivityCaptures.xaml
    /// </summary>
    public partial class ActivityVerificationWindow : Window
    {
        public ActivityVerificationWindow()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            StyleManager.SetTheme(tileViewUserList, new Windows8Theme());
            StyleManager.SetTheme(tileViewActivityList, new Windows8Theme());
            StyleManager.SetTheme(radTimeBar, new Windows8Theme());
            //StyleManager.SetTheme(tileViewActivityCaptures, new Windows8Theme());
            StyleManager.SetTheme(radToolBar, new Windows8Theme());
        }

        private void RadFluidContentControl_MouseEnter_1(object sender, MouseEventArgs e)
        {
            try
            {
                var s = sender as RadFluidContentControl;
                if (s.State == FluidContentControlState.Normal)
                {
                    s.Height = 205;
                    s.State = FluidContentControlState.Large;
                }
                else
                {
                    s.Height = Convert.ToDouble("NaN");
                }
            }
            catch
            { }
        }

        private void RadFluidContentControl_MouseLeave_1(object sender, MouseEventArgs e)
        {
            try
            {
                var s = sender as RadFluidContentControl;
                    s.Height = Convert.ToDouble("NaN");

            }
            catch
            {

            }

        }
    }
}
