using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS.ActivityVerification.Azure;
using PS.ActivityVerification.PSServiceReference;
using PS.ActivityVerification.Logging;
using PS.ActivityVerification.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Task = System.Threading.Tasks.Task;

namespace PS.ActivityVerification.ViewModel
{
    public class SubmitOutputViewModel : BaseViewModel
    {
        //public readonly BlobClient AttachmentsBlobClient = new BlobClient(AzureInitializer.AttachmentsBlobContainer,
            //"base", new DebugLogger());

        private readonly ActivityModel _activity;

        private readonly ObservableCollection<AttatchmentModel> _attachments =
            new ObservableCollection<AttatchmentModel>();

        private string _emailCC;
        private string _emailTo;
        private string _tfsPath;

        private string _whatIsDone;

        public SubmitOutputViewModel(ActivityModel activityModel)
        {
            SendEmailCommand = new RelayCommand(SendEmailExecute);
            RemoveAttachmentCommand = new RelayCommand<AttatchmentModel>(RemoveAttachment);
            UplaodCommand = new RelayCommand(UploadExecute);

            _activity = activityModel;
        }

        public string WhatIsDone
        {
            get { return _whatIsDone; }
            set
            {
                _whatIsDone = value;
                RaisePropertyChanged(() => WhatIsDone);
            }
        }

        public string TfsPath
        {
            get { return _tfsPath; }
            set
            {
                _tfsPath = value;
                RaisePropertyChanged(() => TfsPath);
            }
        }

        public string EmailTo
        {
            get { return _emailTo; }
            set
            {
                _emailTo = value;
                RaisePropertyChanged(() => EmailTo);
            }
        }

        public string EmailCC
        {
            get { return _emailCC; }
            set
            {
                _emailCC = value;
                RaisePropertyChanged(() => EmailCC);
            }
        }

        public ObservableCollection<AttatchmentModel> Attachments
        {
            get { return _attachments; }
        }

        public RelayCommand UplaodCommand { get; private set; }
        public RelayCommand SendEmailCommand { get; private set; }
        public RelayCommand<AttatchmentModel> RemoveAttachmentCommand { get; private set; }


        private async void UploadExecute()
        {
            AttatchmentModel attachmentLink = await UploadImage();
            if (attachmentLink != null)
                Attachments.Add(attachmentLink);
        }

        private async Task<AttatchmentModel> UploadImage()
        {
            //using (var fileDialog = new OpenFileDialog())
            //{
            //    if (fileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string filePath = fileDialog.FileName;
            //        string url = string.Empty;//await AttachmentsBlobClient.WriteFileAsync(filePath, FileMode.OpenOrCreate);
            //        return new AttatchmentModel
            //        {
            //            Url = url,
            //            Name = Path.GetFileName(fileDialog.FileName)
            //        };
            //    }
                return null;
            //}
        }

        private async void RemoveAttachment(AttatchmentModel attachment)
        {
            AttatchmentModel link = Attachments.FirstOrDefault(i => i.Url == attachment.Url);
            Attachments.Remove(link);
            //await AttachmentsBlobClient.DeleteAsync(attachment.Url);
        }

        private async void SendEmailExecute()
        {
            if (string.IsNullOrEmpty(WhatIsDone))
            {
                MessageBox.Show("please fill what you had done in this activity");
                return;
            }

            string message = WhatIsDone + "</br>";
            message += "Shared link: " + TfsPath + "</br>";
            foreach (AttatchmentModel attachment in Attachments)
            {
                message += @"attchment: <a href=""" + attachment.Url + @""" >" + attachment.Name + "</a>" + "</br>";
            }

            message += "Best Regards";

            await SendEmailNotification(EmailTo, message, "Activity output", EmailCC);
        }

        private async Task SendEmailNotification(string to, string message, string subject, string cc)
        {
            using (var smtpClient = new SmtpClient())
            {
                //smtpClient.Credentials = new NetworkCredential("vinnikovoleg@gmail.com", "Pusher0668901747");
                //smtpClient.EnableSsl = true;
                var mailMessage = new MailMessage();
                mailMessage.Body = message;

                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                if (!string.IsNullOrEmpty(to))
                    mailMessage.To.Add(to);
                else
                    return;
                if (!string.IsNullOrEmpty(cc))
                    mailMessage.CC.Add(cc);
                await smtpClient.SendMailAsync(mailMessage);
            }
            SetActivityCompleted();
            Messenger.Default.Send(new SubmitOutputMessage {Close = true});
        }

        private async void SetActivityCompleted()
        {
            var activity =
                await ActivityOptimizationSystemServiceClient.GetActivityByActivityIdAsync(_activity.ActivityID);
            var statuses =
                await ActivityOptimizationSystemServiceClient.GetActivityStatusAsync();

            if (activity.IsErrorReturned || statuses.IsErrorReturned) return;

            activity.Value.ActivityStatusId = statuses.Value.Single(i => i.StatusName == "Completed").Id;
            await ActivityOptimizationSystemServiceClient.AddOrUpdateActivityAsync(activity.Value);
            Messenger.Default.Send(new RemoveActivityMessage {ActivityId = activity.Value.Id});
        }
    }

    public class AttatchmentModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}