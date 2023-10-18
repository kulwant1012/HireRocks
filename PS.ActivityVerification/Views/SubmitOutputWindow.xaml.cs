using PS.ActivityVerification.Messages;
using PS.ActivityVerification.ViewModel;
using GalaSoft.MvvmLight.Messaging;
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

namespace PS.ActivityVerification.Views
{
    /// <summary>
    /// Interaction logic for SubmitOutputWindow.xaml
    /// </summary>
    public partial class SubmitOutputWindow : Window
    {
        public SubmitOutputWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<SubmitOutputMessage>(this, (e) =>
            {
                if (e.Close)
                {
                    this.Close();
                }
            });
        }


        private SubmitOutputViewModel VM
        {
            get { return DataContext as SubmitOutputViewModel; }
        }

        private async void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);


            //    System.IO.FileStream fStream;
            //    if (System.IO.File.Exists(docPath[0]))
            //    {
            //        try
            //        {
            //            var url = await VM.AttachmentsBlobClient.WriteFileAsync(docPath[0], FileMode.OpenOrCreate);
            //            VM.Attachments.Add(new AttatchmentModel() { Url = url, Name = System.IO.Path.GetFileName(docPath[0]) });
            //        }
            //        catch (System.Exception)
            //        {
            //            MessageBox.Show("File could not be opened. Make sure the file is a text file.");
            //        }
            //    }
            //}
        }
    }
}
