using System;
using System.IO;
using System.Net.NetworkInformation;
using PS.ActivityVerification.PSServiceReference;
using GalaSoft.MvvmLight;
using Raven.Abstractions.Data;
using Attachment = Raven.Abstractions.Data.Attachment;
using Microsoft.AspNet.SignalR.Client;
using System.Configuration;
using System.Threading;
namespace PS.ActivityVerification.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        public static HubConnection _hubConnection;
        public static IHubProxy _notificationHub;

        static BaseViewModel()
        {
            ActivityOptimizationSystemServiceClient = new ActivityOptimizationSystemServiceClient();
            MediaElementServiceClient = new MediaElementServiceClient();
            ActivityVerificationServiceClient = new ActivityVerificationServiceClient();
            OfflineDataBaseRepository = new OfflineDataBaseRepository<Entity>();
            SyncOfflineDataWithServer();
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }

        protected static InitializationServiceClient InitializationServiceClient { get; set; }

        protected static ActivityOptimizationSystemServiceClient ActivityOptimizationSystemServiceClient { get; set; }

        protected static ActivityVerificationServiceClient ActivityVerificationServiceClient { get; set; }

        protected static MediaElementServiceClient MediaElementServiceClient { get; set; }

        protected static bool IsCloseButtonNotClicked { get; set; }

        private string _errorMessage { get; set; }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        private bool _isBusy { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged(() => IsBusy);
                }
            }
        }

        public static OfflineDataBaseRepository<Entity> OfflineDataBaseRepository { get; set; }

        private static void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
                SyncOfflineDataWithServer();
        }

        //Method tWhich SYNC Offline stored Data to Raven Server Instance ( Call when first time Application start OR when network become available)
        private static async void SyncOfflineDataWithServer()
        {
            try
            {
                foreach (
                    ActivityCapture activityCapture in await OfflineDataBaseRepository.GetAllAsync<ActivityCapture>())
                {
                    Attachment thumbnailImage = OfflineDataBaseRepository.GetAttachment(activityCapture.ThumbnailImage);
                    var addThumbnailImageResult =
                        await
                            MediaElementServiceClient.UploadMediaAsync(new AddMediaFile
                            {
                                Id = thumbnailImage.Key,
                                MediaFile = ConvertStreamToByteArray(thumbnailImage.Data()),
                                ContentType = thumbnailImage.Metadata["Content-Type"].ToString()
                            });
                    if (addThumbnailImageResult.IsErrorReturned)
                        continue;

                    Attachment fullImage = OfflineDataBaseRepository.GetAttachment(activityCapture.FullImage);
                    var addFullImageResult =
                        await
                            MediaElementServiceClient.UploadMediaAsync(new AddMediaFile
                            {
                                Id = fullImage.Key,
                                MediaFile = ConvertStreamToByteArray(fullImage.Data()),
                                ContentType = fullImage.Metadata["Content-Type"].ToString()
                            });
                    if (addFullImageResult.IsErrorReturned)
                        continue;

                    var addActivityCaptureResult =
                        await ActivityVerificationServiceClient.AddCapturedInformationAsync(activityCapture);
                    if (addActivityCaptureResult.IsErrorReturned)
                        continue;

                    OfflineDataBaseRepository.DeleteAttachment(activityCapture.ThumbnailImage);
                    OfflineDataBaseRepository.DeleteAttachment(activityCapture.FullImage);
                    OfflineDataBaseRepository.Delete(activityCapture.Id);
                }

                foreach (MatchedKeyword keyword in await OfflineDataBaseRepository.GetAllAsync<MatchedKeyword>())
                {
                    var addKeywordResult =
                        await ActivityVerificationServiceClient.AddOrUpdateMatchedKeywordAsync(keyword);
                    if (addKeywordResult.IsErrorReturned)
                        continue;

                    OfflineDataBaseRepository.Delete(keyword.Id);
                }
            }

            catch (Exception ex)
            {
            }
        }

        private static byte[] ConvertStreamToByteArray(Stream dataStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                dataStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}