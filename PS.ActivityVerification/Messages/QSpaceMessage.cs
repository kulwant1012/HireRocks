using PS.ActivityVerification.ViewModel;

namespace PS.ActivityVerification.Messages
{
    public class QSpaceMessage
    {
        public QSpaceMessage(SelectQSpaceViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public QSpaceMessage()
        {
        }

        public SelectQSpaceViewModel ViewModel { get; set; }
    }

    public struct CloseQSpaceWindow
    {
    }
}