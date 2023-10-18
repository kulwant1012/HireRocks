using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Raven.Abstractions.Data;
using Raven.Client.Document;

namespace PS.ActivityManagementStudio.Converters
{
    public class UrlToBitmapConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            //Update with new database and credentials Need to update
            var store = new DocumentStore();
            //store.Url = "http://eqosoft-vst2013.cloudapp.net:83";
            store.Url = "http://192.169.235.121/PSService";
            //string userName = "abc";
            //string password = "abc";
            store.Credentials = new NetworkCredential();
            store.Initialize();
            store.OpenSession();
            store.DefaultDatabase = "AMS-ACS";
            Attachment attachment = store.DatabaseCommands.GetAttachment(value as string);
                //Value Example: "863debd9-98d8-4b75-9681-12a5546c4537"
            Func<Stream> attachmentFunc = attachment.Data;

            //Creating Image....
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = attachmentFunc();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();

            return bitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}