using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class MainWindowMessage
    {
        public MainWindowMessage(MainWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public MainWindowMessage()
        {
        }

        public MainWindowViewModel ViewModel { get; set; }
    }

    public struct CloseMainWindowMessage
    {
    }
}