using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class ActivityVerificationWindowMessage
    {
        public ActivityVerificationWindowMessage(ActivityVerificationViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public ActivityVerificationWindowMessage()
        {
        }

        public ActivityVerificationViewModel ViewModel { get; set; }
    }

    public struct CloseActivityVerificationWindow
    {
    }
}