using PS.ActivityVerification.ViewModel;

namespace PS.ActivityVerification.Messages
{
    public class ActivityMessage
    {
        public ActivityMessage(SelectActivityViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public ActivityMessage()
        {
        }

        public SelectActivityViewModel ViewModel { get; set; }
    }

    public struct CloseActivityWindow
    {
    }
}