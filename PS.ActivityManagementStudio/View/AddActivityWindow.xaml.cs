using System;
using System.Collections.Generic;
using System.IO;
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

using PS.ActivityManagementStudio.ViewModel;
using System.Globalization;

namespace PS.ActivityManagementStudio.View
{
    public partial class AddUpdateActivityWindow : Window
    {
        public AddUpdateActivityWindow()
        {
            InitializeComponent();
        }

        private ActivityViewModel VM
        {
            get { return DataContext as ActivityViewModel; }
        }

        private async void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);


                System.IO.FileStream fStream;
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        //var url = await VM.AttachmentsBlobClient.WriteFileAsync(docPath[0], FileMode.OpenOrCreate);
                        //VM.Attachments.Add(url);
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }
    }
}
