using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class QSpaceWindowMessage
    {
        public QSpaceWindowMessage(QSpaceViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public QSpaceWindowMessage()
        {
        }

        public QSpaceViewModel ViewModel { get; set; }
    }

    public struct CloseQSpaceWindow
    {
    }
}