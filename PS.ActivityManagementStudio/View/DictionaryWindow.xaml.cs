using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for DictionaryWindow.xaml
    /// </summary>
    public partial class DictionaryWindow : Window
    {
        public DictionaryWindow()
        {
            InitializeComponent();
            //StyleManager.SetTheme(radTileView, new Windows8Theme());
        }
        public string selectedTiles { get; set; }

        private void RadTileView_TileSelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var radTileView = sender as RadTileView;
            if (radTileView.SelectedItems.Count > 0)
            {
               var radTileSelectedItem  = radTileView.SelectedItems[0];
               radTileView.MaximizedItem = radTileSelectedItem;
            }
            else
            {
                radTileView.MaximizedItem = null;
            }
        }

        private void RadTileViewItem_MouseEnter_1(object sender, MouseEventArgs e)
        {
            try
            {
                var s = sender as RadFluidContentControl;
                s.State = FluidContentControlState.Large;
            }
            catch
            {}
        }

        private void RadTileViewItem_MouseLeave_1(object sender, MouseEventArgs e)
        {
            try
            {
                var s = sender as RadFluidContentControl;
                s.State = FluidContentControlState.Large;
            }
            catch
            { }
        }
    }
}
